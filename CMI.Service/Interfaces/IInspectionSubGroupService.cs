
namespace CMI.Service.Interfaces
{
    /// <summary>
    /// زیرگروه بازرسی
    /// </summary>
    public interface IInspectionSubGroupService : IBaseService<InspectionSubGroup, CmiDataContext, InspectionSubGroupRepository>
    {
        // Functions.
        void Delete(long id);
        InspectionSubGroup? Get(long id);
        InspectionSubGroup? GetWithIsUsedInOtherEntities(long id);
        string Add(InspectionSubGroup entity);
        List<InspectionSubGroup> SearchInspectionSubGroupsByGroupId(string searchTerm, long groupId);
    }
}
