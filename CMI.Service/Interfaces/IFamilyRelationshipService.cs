namespace CMI.Service.Interfaces;

/// <summary>
/// والدین
/// </summary>
public interface IFamilyRelationshipService : IBaseService<FamilyRelationship, CmiDataContext, FamilyRelationshipRepository>
{
    // Functions.
    void Delete(long id);
    void DeleteRange(long id);
    FamilyRelationship? Get(long id);
}
