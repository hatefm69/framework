

namespace CMI.Service.Interfaces;

/// <summary>
/// معلم
/// </summary>
public interface ITeacherService : IBaseService<Teacher, CmiDataContext, TeacherRepository>
{
    void AddRecord(TeacherWithFamilyRelation entity, IFormFileCollection files);
    void AddRecord(TeacherWithFamilyRelation entity);

    // Functions.
    void Delete(long id);
    TeacherWithFamilyRelation? Get(long id);
    TeacherWithAttachment? GetWithAttachment(long id);
    List<OutTeacher> SearchRecords(PageParams pageParams, ExpressionBindType expressionBindType = ExpressionBindType.AndAlso);
    void UpdateRecord(TeacherWithFamilyRelation entity, IFormFileCollection files);
    void UpdateRecord(TeacherWithFamilyRelation entity);
}

