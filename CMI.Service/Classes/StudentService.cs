using ClosedXML.Excel;
using FIS.Tools;

namespace CMI.Service.Classes;

/// <summary>
/// دانش آموز
/// </summary>
public class StudentService : BaseService<Student, CmiDataContext, StudentRepository>, IStudentService
{
    private CmiDataContext _cmiDataContext { get; set; }
    // Events.
    public StudentService(CmiDataContext dataContext, IServiceLocator repositoryLocator) : base(dataContext, repositoryLocator)
    {
        _cmiDataContext = dataContext;
        dataContext.GetUserInformaion = () => new UserInformation
        {
            Identity = Request.GetUserName(),
            IP = Request.GetUserIp()
        };
    }

    public StudentWithFamilyRelation? Get(long id)
    {
        var entity = EntityRepository.Get(id);
        if (entity == null)
            throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
        return entity;
    }
    public StudentWithAttachment? GetWithAttachment(long id)
    {
        var entity = EntityRepository.GetWithAttachment(id);
        if (entity == null)
            throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
        return entity;
    }

    public override void UpdateRecord(Student entity)
    {
        GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>().DeleteRange(entity.Id, TableEnum.Student);
        base.UpdateRecord(entity);
    }
    public void UpdateRecord(StudentWithFamilyRelation entity)
    {
        var familyService = GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>();
        familyService.DeleteRange(entity.Student.Id, TableEnum.Student);
        familyService.AddRecords(entity.FamilyRelationships.ToList());
        base.UpdateRecord(entity.Student);
    }
    public void UpdateRecord(StudentWithFamilyRelation entity, IFormFileCollection files)
    {

        var familyRelationshipService = GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>();

        familyRelationshipService.DeleteRange(entity.Student.Id, TableEnum.Student);
        var sanaFileInfo = new List<SanaFileInfo>();
        var attachmentService = GetService<Attachment, AttachmentRepository, AttachmentService>();
        Transaction.Begin(onTask: () =>
        {
            if (!(files == null || files.Count == 0))
            {
                sanaFileInfo = SanaHelper.UploadFiles(files);

                entity.Student.Id = _cmiDataContext.Next_SEQ().Value;
                base.UpdateRecord(entity.Student);

                attachmentService.UpdateRecords(sanaFileInfo.Select(x => new Attachment
                {
                    FileName = x.Filename,
                    TableId = TableEnum.Student,
                    SanaId = x.Id,
                    RecordId = entity.Student.Id
                }).ToList());
                familyRelationshipService.AddRecords(entity.FamilyRelationships.Select(x => new FamilyRelationship
                {
                    FamilyRelationshipId = x.FamilyRelationshipId,
                    FullName = x.FullName,
                    RecordId = entity.Student.Id,
                    TableId = TableEnum.Student,
                }).ToList());
                CommitDatabaseChanges();
            }
        },
        onCommit: () =>
        {

        },
        onRollBack: (exception) =>
        {
            if (sanaFileInfo != null)
            {
                var sana = ExternalServices.GetSana();

                sanaFileInfo.ForEach(file =>
                {
                    var result = sana.DeleteFile(CmiDataContext.AppName, file.Id);
                });
            }
        });



        //if (!(files == null || files.Count == 0))
        //{


        //    var sanaResult = SanaHelper.UploadFiles(files);
        //    base.UpdateRecord(entity);

        //    attachmentService.AddRecords(sanaResult.Select(x => new Attachment
        //    {
        //        FileName = x.Filename,
        //        TableId = TableEnum.Student,
        //        SanaId = x.Id,
        //        RecordId = entity.Id
        //    }).ToList());

        //}

    }


    public List<OutStudent> SearchRecords(PageParams pageParams)
    {
        return EntityRepository.SearchRecords(pageParams);
    }
    public List<OutStudent> GetAll()
    {
        return EntityRepository.GetAll().Select(z => new OutStudent
        {
            BirthDate = z.BirthDate,
            CityTitle = z.City?.Title,
            FirstName = z.FirstName,
            LastName = z.LastName,
            IsActive = z.IsActive,
            LevelTitle = z.Level?.Title,
            FullName = $"{z.FirstName} {z.LastName}",
            Id = z.Id
        }).ToList();
    }

    public void Delete(long id)
    {
        var entity = EntityRepository.GetPureStudent(id);

        if (entity == null) return;
        EntityRepository.Remove(entity);
    }
    public override void AddRecord(Student entity)
    {
        entity.Id = _cmiDataContext.Next_SEQ().Value;
        //entity.AddEducationalQualification("پیش دبستانی", new Score(0));
        base.AddRecord(entity);
    }
    public void AddRecord(StudentWithFamilyRelation entity)
    {
        entity.Student.Id = _cmiDataContext.Next_SEQ().Value;
        //entity.AddEducationalQualification("پیش دبستانی", new Score(0));

        var familyRelationshipService = GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>();
        base.AddRecord(entity.Student);
        familyRelationshipService.AddRecords(entity.FamilyRelationships.ToList());
    }
    public void AddRecord(StudentWithFamilyRelation entity, IFormFileCollection files)
    {

        var familyRelationshipService = GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>();
        var attachmentService = GetService<Attachment, AttachmentRepository, AttachmentService>();
        var sanaFileInfo = new List<SanaFileInfo>();

        Transaction.Begin(onTask: () =>
        {
            if (!(files == null || files.Count == 0))
            {


                //var file=files.GroupBy(x => x.Name);
                //sanaFileInfo = SanaHelper.UploadFiles(files);
                entity.Student.Id = _cmiDataContext.Next_SEQ().Value;
                base.AddRecord(entity.Student);

                if (files.GroupBy(x => x.FileName).Where(z => z.Count() > 1).Any())
                    new InformationException("نام فایل ها نباید یکسان باشد.");

                sanaFileInfo = SanaHelper.UploadFiles(files);

                attachmentService.AddRecords(sanaFileInfo.Select(x => new Attachment
                {
                    FileName = x.Filename,
                    TableId = TableEnum.Student,
                    SanaId = x.Id,
                    RecordId = entity.Student.Id,
                    AttachmentCategoryId = files.First(z => z.FileName == x.Filename).Name.Contains("signature") ? AttachementCategoryEnum.Signature : AttachementCategoryEnum.Excel
                }).ToList());

                familyRelationshipService.AddRecords(entity.FamilyRelationships.Select(x => new FamilyRelationship
                {
                    FamilyRelationshipId = x.FamilyRelationshipId,
                    FullName = x.FullName,
                    RecordId = entity.Student.Id,
                    TableId = TableEnum.Student,
                }).ToList());
                CommitDatabaseChanges();
            }
        },
        onCommit: () =>
        {

        },
        onRollBack: (exception) =>
        {
            if (sanaFileInfo != null)
            {
                var sana = ExternalServices.GetSana();

                sanaFileInfo.ForEach(file =>
                {
                    var result = sana.DeleteFile(CmiDataContext.AppName, file.Id);
                });
            }
        });

    }

    public byte[] GetCombinedReportExcelFile(List<OutStudent> students, string header)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("گزارش ترکیبی");
        worksheet.RightToLeft = true;
        worksheet.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        worksheet.Style.Font.FontSize = 12;

        // ==== Header ====
        worksheet.Cell(1, 1).Value = header;
        worksheet.Range("A1:G1").Merge().Style
            .Font.SetBold()
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Row(1).Height = 25;

        // ==== Columns ====
        var columns = new[]
        {
            "ردیف", "شناسه", "نام", "نام خانوادگی", "شهر", "پایه", "وضعیت",
        };

        for (int i = 0; i < columns.Length; i++)
            worksheet.Cell(2, i + 1).Value = columns[i];

        var colCount = columns.Length;
        worksheet.Range(1, 1, 2, colCount).Style
            .Font.SetBold()
            .Fill.SetBackgroundColor(XLColor.LightGray)
            .Border.SetOutsideBorder(XLBorderStyleValues.Thin)
            .Border.SetInsideBorder(XLBorderStyleValues.Thin);

        // ==== داده‌ها ====

        int currentRow = 3;
        int provinceRowNumber = 1; // شماره برای هر استان

        var studentsOrdered = students.OrderBy(g => g.Id).ToList();
        studentsOrdered.ForEach(student =>
        {
            worksheet.Cell(currentRow, 1).Value = studentsOrdered.IndexOf(student) + 1;
            worksheet.Cell(currentRow, 2).Value = student.Id;
            worksheet.Cell(currentRow, 3).Value = student.FirstName;
            worksheet.Cell(currentRow, 4).Value = student.LastName;
            worksheet.Cell(currentRow, 5).Value = student.CityTitle;
            worksheet.Cell(currentRow, 6).Value = student.LevelTitle;
            worksheet.Cell(currentRow, 7).Value = student.IsActiveStatus;

            if (currentRow % 2 == 0)
                worksheet.Range(currentRow, 1, currentRow, colCount).Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(XLColor.LightGray);
            ++currentRow;
        });


        worksheet.Column(3).Width = 20;
        worksheet.Column(4).Width = 40;
        worksheet.Column(3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        worksheet.Column(4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Range($"A{currentRow}:D{currentRow}").Merge();
        worksheet.Range($"E{currentRow}:G{currentRow}").Merge();
        worksheet.Cell(currentRow, 1).Value = "تعداد کل:";
        worksheet.Cell(currentRow, 5).Value = students.Count();
        worksheet.Range(currentRow, 1, currentRow, colCount).Style.Font.SetFontColor(XLColor.Orange)
          .Font.SetBold()
          .Fill.SetBackgroundColor(XLColor.LightSlateGray)
          .Border.SetOutsideBorder(XLBorderStyleValues.Thin)
          ;

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

}