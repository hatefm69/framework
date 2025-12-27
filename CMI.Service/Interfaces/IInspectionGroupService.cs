namespace CMI.Service.Interfaces;

/// <summary>
/// گروه بازرسی
/// </summary>
public interface IInspectionGroupService : IBaseService<InspectionGroup, CmiDataContext, InspectionGroupRepository>
{
    // Functions.
    void Delete(long id);
    InspectionGroup? Get(long id);
    InspectionGroup? GetWithIsUsedInOtherEntities(long id);
    string Add(InspectionGroup entity);
    ZimaAutoCompleteItem[] GetAllForAutoComplete(string searchTerm);
    List<IdTitle> GetAllReferralGroups(PageParams pageParams);
    List<InspectionGroup> GetActiveInspectionGroups(string searchText);
    List<InspectionGroup> GetInspectionGroups(string searchText);

    // *************************************************************************** ShareController
    ZimaAutoCompleteItem[] GetRegionsFromAfraForAutoComplete(string searchText);
}