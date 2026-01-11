namespace CMI.Model.Repositories;

/// <summary>
/// والدین
/// </summary>
public class FamilyRelationshipRepository : Repository<FamilyRelationship, CmiDataContext>
{
    // Events.
    public FamilyRelationshipRepository() { }

    public FamilyRelationshipRepository(CmiDataContext dataContext, IServiceLocator entityLocator) : base(dataContext, entityLocator) { }

    #region Private Functions.

    #endregion

    #region Public Functions.

    public FamilyRelationship? Get(long id) => EntityQueryable.SingleOrDefault(rd => rd.Id == id);

    public List<FamilyRelationship>? GetByRecordById(long id, TableEnum table) => EntityQueryable.Where(rd => rd.RecordId == id && rd.TableId == table).ToList();
    public List<FamilyRelationship> GetAll() => EntityQueryable.ToList();

    #endregion
}