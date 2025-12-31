namespace CMI.Service.Classes;

/// <summary>
/// دانش آموز
/// </summary>
public class StudentService : BaseService<Student, CmiDataContext, StudentRepository>, IStudentService
{
    // Events.
    public StudentService(CmiDataContext dataContext, IServiceLocator repositoryLocator) : base(dataContext, repositoryLocator)
    {
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

    public override void UpdateRecord(Student entity)
    {
        GetService<FamilyRelationship, FamilyRelationshipRepository, FamilyRelationshipService>().DeleteRange(entity.Id);
        base.UpdateRecord(entity);
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
}