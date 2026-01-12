namespace CMI.Model.Repositories;

/// <summary>
/// دانش آموز
/// </summary>
public class StudentRepository : Repository<Student, CmiDataContext>
{
    // Events.
    public StudentRepository() { }

    public StudentRepository(CmiDataContext dataContext, IServiceLocator entityLocator) : base(dataContext, entityLocator) { }

    #region Private Functions.

    #endregion

    #region Public Functions.

    public StudentWithFamilyRelation? Get(long id)
    {
        var familyRepoTBL = GetRepository<FamilyRelationship, FamilyRelationshipRepository>().EntityQueryable;
        return EntityQueryable
        .Include(x => x.Level)
        .Include(x => x.City)
        .Select(x => new StudentWithFamilyRelation
        {
            Student = x
           ,
            FamilyRelationships
             = (familyRepoTBL
                .AsNoTracking()
                .Where(x => x.RecordId == id)
                .ToList())
        })
        //.Include(x => x.FamilyRelationships)
        //.Include(x => x.EducationalQualification).Select(x => x)
        .SingleOrDefault(rd => rd.Student.Id == id);
    }
    public Student? GetPureStudent(long id)
    {
        var familyRepoTBL = GetRepository<FamilyRelationship, FamilyRelationshipRepository>().EntityQueryable;
        return EntityQueryable
        .Include(x => x.Level)
        .Include(x => x.City)
        //.Include(x => x.FamilyRelationships)
        //.Include(x => x.EducationalQualification).Select(x => x)
        .SingleOrDefault(rd => rd.Id == id);
    }
    public StudentWithAttachment? GetWithAttachment(long id)
    {
        var attachmentRepoTBL = GetRepository<Attachment, AttachmentRepository>().EntityQueryable;
        return EntityQueryable
            .AsNoTracking()
            .Include(x => x.Level)
            .Include(x => x.City)
            //.Include(x => x.EducationalQualification)
            .Select(x => new StudentWithAttachment
            {
                Student = x,
                Attachments = attachmentRepoTBL
                .AsNoTracking()
                .Where(x => x.RecordId == id)
                .ToList()
            })
            .SingleOrDefault(rd => rd.Student.Id == id);

    }
    //return null;
    //})



    public List<Student> GetAll() => EntityQueryable.Include(x => x.Level).Include(x => x.City).ToList();
    public List<OutStudent> SearchRecords(PageParams pageParams)
    {
        var studentTbl = EntityQueryable.AsNoTracking();
        pageParams.SortParams = new List<SortParam> { new() { OrderBy = "id", SortOrder = "desc" } };
        return FilterData(pageParams).Select(student => new OutStudent
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            LevelTitle = student.Level!.Title,
            FullName = $"{student.FirstName} {student.LastName}",
            CityTitle = student.City.Title,
            IsActive = student.IsActive,
            BirthDate = student.BirthDate
        }).ToList();
    }

    #endregion
}