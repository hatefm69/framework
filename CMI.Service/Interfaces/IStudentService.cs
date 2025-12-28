
namespace CMI.Service.Interfaces;

/// <summary>
/// دانش آموز
/// </summary>
public interface IStudentService : IBaseService<Student, CmiDataContext, StudentRepository>
{
    // Functions.
    void Delete(long id);
    Student? Get(long id);
    List<OutStudent> SearchRecords(PageParams pageParams, ExpressionBindType expressionBindType = ExpressionBindType.AndAlso);
}
