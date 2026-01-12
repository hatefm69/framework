

namespace CMI.Service.Interfaces;

/// <summary>
/// دانش آموز
/// </summary>
public interface IStudentService : IBaseService<Student, CmiDataContext, StudentRepository>
{
    void AddRecord(StudentWithFamilyRelation entity, IFormFileCollection files);
    void AddRecord(StudentWithFamilyRelation entity);

    // Functions.
    void Delete(long id);
    StudentWithFamilyRelation? Get(long id);
    List<OutStudent> GetAll();
    byte[] GetCombinedReportExcelFile(List<OutStudent> students, string header);
    StudentWithAttachment? GetWithAttachment(long id);
    List<OutStudent> SearchRecords(PageParams pageParams);
    void UpdateRecord(StudentWithFamilyRelation entity, IFormFileCollection files);
    void UpdateRecord(StudentWithFamilyRelation entity);
}
