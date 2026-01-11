namespace CMI.Service.Classes;

/// <summary>
/// والدین
/// </summary>
public class FamilyRelationshipService : BaseService<FamilyRelationship, CmiDataContext, FamilyRelationshipRepository>, IFamilyRelationshipService
{
    // Events.
    public FamilyRelationshipService(CmiDataContext dataContext, IServiceLocator repositoryLocator) : base(dataContext, repositoryLocator)
    {
    }

    #region Other Functinos.



    #endregion

    #region Web API Function.

    public void Delete(long id)
    {
        var entity = EntityRepository.Get(id);

        if (entity == null) return;
        EntityRepository.Remove(entity);
    }
    public void DeleteRange(long id, TableEnum table)
    {
        var familyRelationships = EntityRepository.GetByRecordById(id, table);
        EntityRepository.RemoveRange(familyRelationships);
    }
    public FamilyRelationship? Get(long id)
    {
        var entity = EntityRepository.Get(id);

        if (entity == null)
            throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
        return entity;
    }

    #endregion
}