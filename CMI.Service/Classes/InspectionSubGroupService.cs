namespace CMI.Service.Classes;
/// <summary>
/// زیرگروه بازرسی
/// </summary>
public class InspectionSubGroupService : BaseService<InspectionSubGroup, CmiDataContext, InspectionSubGroupRepository>, IInspectionSubGroupService
{
    public InspectionSubGroupService(CmiDataContext dataContext, IServiceLocator repositoryLocator) : base(dataContext, repositoryLocator)
    {
        dataContext.GetUserInformaion = () => new UserInformation
        {
            Identity = Request.GetUserName(),
            IP = Request.GetUserIp()
        };
    }

    // *********************************************************************** Get

    public override List<InspectionSubGroup> SearchRecords(PageParams pageParams, ExpressionBindType expressionBindType = ExpressionBindType.AndAlso)
    {
        return EntityRepository.SearchRecords(pageParams);
    }

    public InspectionSubGroup? Get(long id)
    {
        var entity = EntityRepository.Get(id);
        return entity == null ? throw new InformationException("داده ای با شناسه ارسالی پیدا نشد") : entity;
    }

    public InspectionSubGroup? GetWithIsUsedInOtherEntities(long id)
    {
        var entity = EntityRepository.Get(id);
        entity!.IsUsedInOtherEntities = IsUsedInOtherEntities(id);
        return entity ?? throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
    }

    public IsUsedInOtherEntities IsUsedInOtherEntities(long id)
    {
        var result = new IsUsedInOtherEntities();
        result.IsUsed = false;

        // todo
        //if (EntityRepository.GetRepository<InspectionSubGroup, InspectionSubGroupRepository>().IsExistByInspectionGroupId(id))
        //{
        //    result.IsUsed = true;
        //    result.EntityNames!.Add("زیر گروه بازرسی");
        //    return result;
        //}
        return result;
    }

    // *********************************************************************** Add

    public string Add(InspectionSubGroup entity)
    {
        if (EntityRepository.IsExistForAdd(entity))
            throw new InformationException("گروه بازرسی با این عنوان قبلا ثبت شده است.");
        base.AddRecord(entity);
        if (entity.IsActive == true)
            entity.DeactivationDate = null;
        //else entity.DeactivationDate = DateHelper.GetTodayDateShamsiWithoutSlash();
        CommitDatabaseChanges();
        return entity.Id.ToString();
    }

    // *********************************************************************** Update

    public override void UpdateRecord(InspectionSubGroup entity)
    {
        if (EntityRepository.IsExistForUpdate(entity))
            throw new InformationException("گروه بازرسی با این عنوان قبلا ثبت شده است.");

        if (entity.IsActive)
        {
            var inspectionGroupService = GetService<InspectionGroup, InspectionGroupRepository, InspectionGroupService>();
            var inspectionGroup = inspectionGroupService.Get(entity.InspectionGroupId);
            if (inspectionGroup!.IsActive == false)
                throw new InformationException("گروه بازرسی این زیرگروه بازرسی غیرفعال است");
        }

        if (entity.IsActive == true)
            entity.DeactivationDate = null;
        //else entity.DeactivationDate = DateHelper.GetTodayDateShamsiWithoutSlash();
        base.UpdateRecord(entity);
    }

    public void DeActiveByInspectionGroupId(long inspectionGroupId)
    {
        var subGroups = EntityRepository.EntityQueryable.Where(x => x.InspectionGroupId == inspectionGroupId && x.IsActive).ToList();
        foreach (var subGroup in subGroups)
        {
            subGroup.IsActive = false;
            //subGroup.DeactivationDate = DateHelper.GetTodayDateShamsiWithoutSlash();
            base.UpdateRecord(subGroup);
        }
    }

    // *********************************************************************** Delete

    public void Delete(long id)
    {
        throw new InformationException("پیاده سازی نشده است");

        // todo
        var isUsedInOtherEntities = IsUsedInOtherEntities(id);
        if (isUsedInOtherEntities.IsUsed)
            throw new InformationException($"از این گروه بازرسی در \"{string.Join(" ، ", isUsedInOtherEntities.EntityNames!)}\" استفاده شده است");

        var entity = EntityRepository.Get(id);
        if (entity == null) return;
        EntityRepository.Remove(entity);
    }

    public List<InspectionSubGroup> SearchInspectionSubGroupsByGroupId(string searchTerm, long groupId)
    {
        var subGroupList = EntityRepository.GetByInspectionGroupId(groupId, true);
        return SearchInspectionSubGroups(subGroupList, searchTerm);
    }

    private List<InspectionSubGroup> SearchInspectionSubGroups(List<InspectionSubGroup> groupList, string searchText)
    {
        var columnList = new List<string> { "Code", "Title" };
        return groupList.Search(columnList, searchText).Take(Constant.AfraMaxLengthData).ToList();
    }
}