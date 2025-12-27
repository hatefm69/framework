

namespace CMI.Model.Repositories;

/// <summary>
/// زیرگروه بازرسی
/// </summary>
public class InspectionSubGroupRepository : Repository<InspectionSubGroup, CmiDataContext>
{
    public InspectionSubGroupRepository() { }

    public InspectionSubGroupRepository(CmiDataContext dataContext, IServiceLocator entityLocator) : base(dataContext, entityLocator) { }

    public List<InspectionSubGroup> SearchRecords(PageParams pageParams)
    {
        var inspectionGroupTbl = EntityQueryable.AsNoTracking();
        var inspectionSubGroupTbl = GetRepository<InspectionGroup, InspectionGroupRepository>().EntityQueryable.AsNoTracking();
        var query = from subGroup in inspectionGroupTbl
                    join groupp in inspectionSubGroupTbl on subGroup.InspectionGroupId equals groupp.Id
                    select new InspectionSubGroup
                    {
                        Id = subGroup.Id,
                        Title = subGroup.Title,
                        InspectionGroupId = subGroup.InspectionGroupId,
                        InspectionGroupTitle = groupp.Title,
                        IsActive = subGroup.IsActive,
                        DeactivationDate = subGroup.DeactivationDate,
                        Description = subGroup.Description,
                    };
        pageParams.SortParams = new List<SortParam> { new SortParam { OrderBy = "id", SortOrder = "desc" } };
        return FilterData(query, pageParams).ToList();
    }

    public InspectionSubGroup? Get(long id)
    {
        var inspectionGroupTbl = EntityQueryable.AsNoTracking();
        var inspectionSubGroupTbl = GetRepository<InspectionGroup, InspectionGroupRepository>().EntityQueryable.AsNoTracking();

        return (from subGroup in inspectionGroupTbl
                join groupp in inspectionSubGroupTbl on subGroup.InspectionGroupId equals groupp.Id
                where subGroup.Id == id
                select new InspectionSubGroup
                {
                    Id = subGroup.Id,
                    Title = subGroup.Title,
                    InspectionGroupId = subGroup.InspectionGroupId,
                    InspectionGroupTitle = groupp.Title,
                    IsActive = subGroup.IsActive,
                    DeactivationDate = subGroup.DeactivationDate,
                    Description = subGroup.Description,
                }).First();
    }

    public List<InspectionSubGroup> GetAll() => EntityQueryable.ToList();

    public bool IsExistForAdd(InspectionSubGroup entity)
    {
        return EntityQueryable.Any(x => x.Title.Trim() == entity.Title.Trim() && x.IsActive);
    }

    public bool IsExistForUpdate(InspectionSubGroup entity)
    {
        return EntityQueryable.Any(x => x.Title.Trim() == entity.Title.Trim() && x.IsActive && x.Id != entity.Id);
    }

    public bool IsExistByInspectionGroupId(long inspectionGroupId)
    {
        return EntityQueryable.AsNoTracking().Any(x => x.InspectionGroupId == inspectionGroupId);
    }

    public bool IsSubGroupForGroup(long inspectionGroupId, long inspectionSubGroupId)
        => EntityQueryable.Any(sg => sg.InspectionGroupId == inspectionGroupId && sg.Id == inspectionSubGroupId);

    public bool IsExistSubGroupIsActive(List<long> listId, bool isActive) => EntityQueryable.Any(sg => listId.Contains(sg.Id) && sg.IsActive == isActive);

    public bool IsExistSubGroup(List<long> listId) => EntityQueryable.Any(sg => listId.Contains(sg.Id));

    public List<InspectionSubGroup> GetByInspectionGroupId(long groupId, bool isActive)
        => EntityQueryable.Where(sg => sg.IsActive == isActive && sg.InspectionGroupId == groupId).ToList();
}