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

    public Student? Get(long id) => EntityQueryable.Include(x => x.Level).SingleOrDefault(rd => rd.Id == id);

    public List<Student> GetAll() => EntityQueryable.ToList();
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
        }).ToList();
    }

    #endregion
}