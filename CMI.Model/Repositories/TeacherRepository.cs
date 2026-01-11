namespace CMI.Model.Repositories;

/// <summary>
/// معلم
/// </summary>
public class TeacherRepository : Repository<Teacher, CmiDataContext>
{
    // Events.
    public TeacherRepository() { }

    public TeacherRepository(CmiDataContext dataContext, IServiceLocator entityLocator) : base(dataContext, entityLocator) { }

    #region Private Functions.

    #endregion

    #region Public Functions.

    public TeacherWithFamilyRelation? Get(long id)
    {
        var familyRepoTBL = GetRepository<FamilyRelationship, FamilyRelationshipRepository>().EntityQueryable;
        return EntityQueryable
        .Include(x => x.Level)
        .Include(x => x.City)
        .Select(x => new TeacherWithFamilyRelation
        {
            Teacher = x
           ,
            FamilyRelationships
             = (familyRepoTBL
                .AsNoTracking()
                .Where(x => x.RecordId == id)
                .ToList())
        })
        //.Include(x => x.FamilyRelationships)
        //.Include(x => x.EducationalQualification).Select(x => x)
        .SingleOrDefault(rd => rd.Teacher.Id == id);
    }
    public Teacher? GetPureTecher(long id)
    {
        var familyRepoTBL = GetRepository<FamilyRelationship, FamilyRelationshipRepository>().EntityQueryable;
        return EntityQueryable
        .Include(x => x.Level)
        .Include(x => x.City)
        //.Include(x => x.FamilyRelationships)
        //.Include(x => x.EducationalQualification).Select(x => x)
        .SingleOrDefault(rd => rd.Id == id);
    }
    public TeacherWithAttachment? GetWithAttachment(long id)
    {
        var attachmentRepoTBL = GetRepository<Attachment, AttachmentRepository>().EntityQueryable;
        return EntityQueryable
            .AsNoTracking()
            .Include(x => x.Level)
            .Include(x => x.City)
            //.Include(x => x.EducationalQualification)
            .Select(x => new TeacherWithAttachment
            {
                Teacher = x,
                Attachments = attachmentRepoTBL
                .AsNoTracking()
                .Where(x => x.RecordId == id)
                .ToList()
            })
            .SingleOrDefault(rd => rd.Teacher.Id == id);

    }
    //return null;
    //})



    public List<Teacher> GetAll() => EntityQueryable.ToList();
    public List<OutTeacher> SearchRecords(PageParams pageParams)
    {
        var teacherTbl = EntityQueryable.AsNoTracking();
        pageParams.SortParams = new List<SortParam> { new() { OrderBy = "id", SortOrder = "desc" } };
        return FilterData(pageParams).Select(teacher => new OutTeacher
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            LevelTitle = teacher.Level!.Title,
            FullName = $"{teacher.FirstName} {teacher.LastName}",
            CityTitle = teacher.City.Title,
            IsActive = teacher.IsActive,
            BirthDate = teacher.BirthDate
        }).ToList();
    }

    #endregion
}

