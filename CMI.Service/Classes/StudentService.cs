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

    public Student? Get(long id)
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
        GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>().DeleteRange(entity.Id);
        base.UpdateRecord(entity);
    }
    public void UpdateRecord(Student entity, IFormFileCollection files)
    {
        GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>().DeleteRange(entity.Id);
        var attachmentService = GetService<Attachment, AttachmentRepository, AttachmentService>();
        if (!(files == null || files.Count == 0))
        {

            var sanaResult = SanaHelper.UploadFiles(files);

            base.UpdateRecord(entity);

            attachmentService.AddRecords(sanaResult.Select(x => new Attachment
            {
                FileName = x.Filename,
                TableId = TableEnum.Student,
                SanaId = x.Id,
                RecordId = entity.Id
            }).ToList());

        }

    }


    public List<OutStudent> SearchRecords(PageParams pageParams, ExpressionBindType expressionBindType = ExpressionBindType.AndAlso)
    {
        return EntityRepository.SearchRecords(pageParams);
    }

    public void Delete(long id)
    {
        var entity = EntityRepository.Get(id);

        if (entity == null) return;
        EntityRepository.Remove(entity);
    }
    public override void AddRecord(Student entity)
    {
        entity.Id = _cmiDataContext.Next_SEQ().Value;
        //entity.AddEducationalQualification("پیش دبستانی", new Score(0));
        base.AddRecord(entity);
    }
    public void AddRecord(Student entity, IFormFileCollection files)
    {
        //entity.AddEducationalQualification("پیش دبستانی", new Score(0));
        var attachmentService = GetService<Attachment, AttachmentRepository, AttachmentService>();
        if (!(files == null || files.Count == 0))
        {
            var sanaResult = SanaHelper.UploadFiles(files);
            entity.Id = _cmiDataContext.Next_SEQ().Value;
            base.AddRecord(entity);

            attachmentService.AddRecords(sanaResult.Select(x => new Attachment
            {
                FileName = x.Filename,
                TableId = TableEnum.Student,
                SanaId = x.Id,
                RecordId = entity.Id
            }).ToList());

        }

    }
}