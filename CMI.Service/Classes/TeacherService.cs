using FIS.Tools;

namespace CMI.Service.Classes;

/// <summary>
/// معلم
/// </summary>
public class TeacherService : BaseService<Teacher, CmiDataContext, TeacherRepository>, ITeacherService
{
    private CmiDataContext _cmiDataContext { get; set; }
    // Events.
    public TeacherService(CmiDataContext dataContext, IServiceLocator repositoryLocator) : base(dataContext, repositoryLocator)
    {
        _cmiDataContext = dataContext;
        dataContext.GetUserInformaion = () => new UserInformation
        {
            Identity = Request.GetUserName(),
            IP = Request.GetUserIp()
        };
    }

    public TeacherWithFamilyRelation? Get(long id)
    {
        var entity = EntityRepository.Get(id);
        if (entity == null)
            throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
        return entity;
    }
    public TeacherWithAttachment? GetWithAttachment(long id)
    {
        var entity = EntityRepository.GetWithAttachment(id);
        if (entity == null)
            throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
        return entity;
    }

    public void UpdateRecord(TeacherWithFamilyRelation entity)
    {
        var familyRelationshipService = GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>();
        familyRelationshipService.DeleteRange(entity.Teacher.Id, TableEnum.Teacher);
        base.UpdateRecord(entity.Teacher);
        familyRelationshipService.AddRecords(entity.FamilyRelationships.ToList());
    }
    public void UpdateRecord(TeacherWithFamilyRelation entity, IFormFileCollection files)
    {
        var familyRelationshipService = GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>();

        familyRelationshipService.DeleteRange(entity.Teacher.Id, TableEnum.Teacher);
        var sanaFileInfo = new List<SanaFileInfo>();
        var attachmentService = GetService<Attachment, AttachmentRepository, AttachmentService>();
        Transaction.Begin(onTask: () =>
        {
            if (!(files == null || files.Count == 0))
            {
                sanaFileInfo = SanaHelper.UploadFiles(files);

                entity.Teacher.Id = _cmiDataContext.Next_SEQ().Value;
                base.UpdateRecord(entity.Teacher);

                attachmentService.UpdateRecords(sanaFileInfo.Select(x => new Attachment
                {
                    FileName = x.Filename,
                    TableId = TableEnum.Teacher,
                    SanaId = x.Id,
                    RecordId = entity.Teacher.Id
                }).ToList());
                familyRelationshipService.AddRecords(entity.FamilyRelationships.Select(x => new FamilyRelationship
                {
                    FamilyRelationshipId = x.FamilyRelationshipId,
                    FullName = x.FullName,
                    RecordId = entity.Teacher.Id,
                    TableId = TableEnum.Teacher,
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


    public List<OutTeacher> SearchRecords(PageParams pageParams, ExpressionBindType expressionBindType = ExpressionBindType.AndAlso)
    {
        return EntityRepository.SearchRecords(pageParams);
    }

    public void Delete(long id)
    {
        var entity = EntityRepository.GetPureTecher(id);

        if (entity == null) return;
        EntityRepository.Remove(entity);
    }
    public override void AddRecord(Teacher entity)
    {
        entity.Id = _cmiDataContext.Next_SEQ().Value;
        //entity.AddEducationalQualification("پیش دبستانی", new Score(0));
        base.AddRecord(entity);
    }
    public void AddRecord(TeacherWithFamilyRelation entity)
    {
        entity.Teacher.Id = _cmiDataContext.Next_SEQ().Value;
        //entity.AddEducationalQualification("پیش دبستانی", new Score(0));

        var familyRelationshipService = GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>();
        base.AddRecord(entity.Teacher);
        familyRelationshipService.AddRecords(entity.FamilyRelationships.ToList());
    }
    public void AddRecord(TeacherWithFamilyRelation entity, IFormFileCollection files)
    {
        var familyRelationshipService = GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>();
        var attachmentService = GetService<Attachment, AttachmentRepository, AttachmentService>();
        var sanaFileInfo = new List<SanaFileInfo>();

        Transaction.Begin(onTask: () =>
        {
            if (!(files == null || files.Count == 0))
            {
                sanaFileInfo = SanaHelper.UploadFiles(files);

                entity.Teacher.Id = _cmiDataContext.Next_SEQ().Value;
                base.AddRecord(entity.Teacher);

                attachmentService.AddRecords(sanaFileInfo.Select(x => new Attachment
                {
                    FileName = x.Filename,
                    TableId = TableEnum.Teacher,
                    SanaId = x.Id,
                    RecordId = entity.Teacher.Id
                }).ToList());

                familyRelationshipService.AddRecords(entity.FamilyRelationships.Select(x => new FamilyRelationship
                {
                    FamilyRelationshipId = x.FamilyRelationshipId,
                    FullName = x.FullName,
                    RecordId = entity.Teacher.Id,
                    TableId = TableEnum.Teacher,
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

