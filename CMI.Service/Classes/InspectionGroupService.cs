namespace CMI.Service.Classes;
/// <summary>
/// گروه بازرسی
/// </summary>
public class InspectionGroupService : BaseService<InspectionGroup, CmiDataContext, InspectionGroupRepository>, IInspectionGroupService
{
    public InspectionGroupService(CmiDataContext dataContext, IServiceLocator repositoryLocator) : base(dataContext, repositoryLocator)
    {
        dataContext.GetUserInformaion = () => new UserInformation
        {
            Identity = Request.GetUserName(),
            IP = Request.GetUserIp()
        };
    }

    public InspectionGroup? Get(long id)
    {
        var entity = EntityRepository.Get(id);
        return entity == null ? throw new InformationException("داده ای با شناسه ارسالی پیدا نشد") : entity;
    }

    public List<IdTitle> GetAllReferralGroups(PageParams pageParams)
    {
        var result = new List<IdTitle>
        {
            new IdTitle
            {
                Id = ReferralGroupEnum.SupervisorOfTheAntiMoneyLaunderingDepartment.ToIntString(),
                Title = ReferralGroupEnum.SupervisorOfTheAntiMoneyLaunderingDepartment.GetDescription()
            },
            new IdTitle
            {
                Id = ReferralGroupEnum.FinalApprover.ToIntString(),
                Title = ReferralGroupEnum.FinalApprover.GetDescription()
            },
            new IdTitle
            {
                Id = ReferralGroupEnum.HeadOfTheAntiMoneyLaunderingDepartment.ToIntString(),
                Title = ReferralGroupEnum.HeadOfTheAntiMoneyLaunderingDepartment.GetDescription()
            },
            new IdTitle
            {
                Id = ReferralGroupEnum.RegionalLeader.ToIntString(),
                Title = ReferralGroupEnum.RegionalLeader.GetDescription()
            },
            new IdTitle
            {
                Id = ReferralGroupEnum.TrackingExpert.ToIntString(),
                Title = ReferralGroupEnum.TrackingExpert.GetDescription()
            }
        };

        pageParams.FilterParams ??= [];
        if (pageParams.TryHasFilter("id", out var id))
            result = result.Where(x => x.Id == id).ToList();
        if (pageParams.TryHasFilter("title", out var title))
            result = result.Where(x => x.Title.Contains(title)).ToList();

        return result;
    }

    public InspectionGroup? GetWithIsUsedInOtherEntities(long id)
    {
        var entity = EntityRepository.Get(id);
        entity!.IsUsedInOtherEntities = IsUsedInOtherEntities(id);
        return entity ?? throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
    }

    public ZimaAutoCompleteItem[] GetAllForAutoComplete(string searchTerm)
    {
        var persons = EntityRepository.GetAllActivesBySearchTerms(searchTerm)
            .Select(p => new ZimaAutoCompleteItem
            {
                Value = p.Id.ToString(),
                Label = p.Title,
            });
        return persons.ToArray();
    }

    public ZimaAutoCompleteItem[] GetRegionsFromAfraForAutoComplete(string searchText)
    {
        var result = ExternalServices.GetAfra().Unit_GetByType(AfraConstant.BranchManagementType);
        if (result != null && result.StatusCode == HttpStatusCode.OK)
        {
            if (searchText.IsNullOrEmpty() == false)
            {
                var filteredData = result.Data.Where(x => x.Code == searchText || x.Name.Contains(searchText)).ToList();
                return filteredData.Select(p => new ZimaAutoCompleteItem
                {
                    Value = p.Code,
                    Label = $"{p.Code}-{p.Name}",
                }).ToArray();
            }

        }
        return Array.Empty<ZimaAutoCompleteItem>();
    }

    public IsUsedInOtherEntities IsUsedInOtherEntities(long id)
    {
        var result = new IsUsedInOtherEntities();
        result.IsUsed = false;
        if (EntityRepository.GetRepository<InspectionSubGroup, InspectionSubGroupRepository>().IsExistByInspectionGroupId(id))
        {
            result.IsUsed = true;
            result.EntityNames!.Add("زیر گروه بازرسی");
            return result;
        }
        // todo: check other entities
        return result;
    }


    public string Add(InspectionGroup entity)
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

    public override void UpdateRecord(InspectionGroup entity)
    {
        if (EntityRepository.IsExistForUpdate(entity))
            throw new InformationException("گروه بازرسی با این عنوان قبلا ثبت شده است.");

        if (entity.IsActive == true) // یوزر فعال کرده
            entity.DeactivationDate = null;
        else // یوزر غیرفعال کرده
        {
            var currentRecord = EntityRepository.Get(entity.Id);
            if (currentRecord!.IsActive == false) // در دیتابیس غیرفعال بوده است
                entity.DeactivationDate = currentRecord.DeactivationDate;
            else // در دیتابیس فعال بوده است
                 //entity.DeactivationDate = DateHelper.GetTodayDateShamsiWithoutSlash();

                // غیرفعال کردن زیر گروه های بازرسی مربوطه
                GetService<InspectionSubGroup, InspectionSubGroupRepository, InspectionSubGroupService>().DeActiveByInspectionGroupId(entity.Id);
        }

        base.UpdateRecord(entity);

        var isUsedInOtherEntities = IsUsedInOtherEntities(entity.Id);
        if (isUsedInOtherEntities.IsUsed)
        {
            EntityRepository.IgnoreProperties(entity,
            [
                nameof(InspectionGroup.Title),
                nameof(InspectionGroup.Description),
            ]);
        }
    }

    public void Delete(long id)
    {
        throw new InformationException("پیاده سازی نشده است");

        // todo
        //var isUsedInOtherEntities = IsUsedInOtherEntities(id);
        //if (isUsedInOtherEntities.IsUsed)
        //    throw new InformationException($"از این گروه بازرسی در \"{string.Join(" ، ", isUsedInOtherEntities.EntityNames!)}\" استفاده شده است");

        var entity = EntityRepository.Get(id);
        if (entity == null) return;
        EntityRepository.Remove(entity);
    }

    public List<InspectionGroup> GetActiveInspectionGroups(string searchText)
    {
        var groupList = EntityRepository.GetInspectionGroups(isActive: true);
        return SearchGroups(groupList, searchText);
    }

    public List<InspectionGroup> GetInspectionGroups(string searchText)
    {
        var groupList = EntityRepository.GetInspectionGroups();
        return SearchGroups(groupList, searchText);
    }
    private List<InspectionGroup> SearchGroups(List<InspectionGroup> inspectionGroupGroupList, string searchText)
    {
        var columnList = new List<string> { "Code", "Title" };
        return inspectionGroupGroupList.Search(columnList, searchText).Take(7).ToList();
    }
}