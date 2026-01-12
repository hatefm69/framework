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


    public List<OutStudent> SearchRecords(PageParams pageParams, ExpressionBindType expressionBindType = ExpressionBindType.AndAlso)
    {
        return EntityRepository.SearchRecords(pageParams);
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
}