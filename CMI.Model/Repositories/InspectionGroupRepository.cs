namespace CMI.Model.Repositories;
/// <summary>
/// گروه بازرسی
/// </summary>
public class InspectionGroupRepository : Repository<InspectionGroup, CmiDataContext>
{
    public InspectionGroupRepository() { }

    public InspectionGroupRepository(CmiDataContext dataContext, IServiceLocator entityLocator) : base(dataContext, entityLocator) { }

    public InspectionGroup? Get(long id)
    {
        return EntityQueryable.AsNoTracking().SingleOrDefault(rd => rd.Id == id);
    }

    public List<InspectionGroup> GetAll() => EntityQueryable.ToList();

    public bool IsExistForAdd(InspectionGroup entity)
    {
        return EntityQueryable.Any(x => x.Title.Trim() == entity.Title.Trim() && x.IsActive);
    }

    public bool IsExistForUpdate(InspectionGroup entity)
    {
        return EntityQueryable.Any(x => x.Title.Trim() == entity.Title.Trim() && x.IsActive && x.Id != entity.Id);
    }

    public List<InspectionGroup> GetAllActivesBySearchTerms(string searchTerm)
    {
        return EntityQueryable.Where(x => x.IsActive && x.Title.Contains(searchTerm)).OrderByDescending(x => x.Id).ToList();
    }
    public List<InspectionGroup> GetInspectionGroups(bool? isActive = null)
    {
        if (isActive.HasValue)
            return EntityQueryable.Where(g => g.IsActive == isActive).ToList();

        return EntityQueryable.ToList();
    }
}