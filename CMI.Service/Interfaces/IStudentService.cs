

namespace CMI.Service.Interfaces;

/// <summary>
/// دانش آموز
/// </summary>
public interface IStudentService : IBaseService<Student, CmiDataContext, StudentRepository>
{
    void AddRecord(Student entity, IFormFileCollection files);

    // Functions.
    void Delete(long id);
    Student? Get(long id);
    StudentWithAttachment? GetWithAttachment(long id);
    List<OutStudent> SearchRecords(PageParams pageParams, ExpressionBindType expressionBindType = ExpressionBindType.AndAlso);
    void UpdateRecord(Student entity, IFormFileCollection files);
}
