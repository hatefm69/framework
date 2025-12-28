namespace CMI.Model.Repositories;

/// <summary>
/// شهر
/// </summary>
public class CityRepository : Repository<City, CmiDataContext>
{
    // Events.
    public CityRepository() { }

    public CityRepository(CmiDataContext dataContext, IServiceLocator entityLocator) : base(dataContext, entityLocator) { }

    #region Private Functions.

    #endregion

    #region Public Functions.

    public City? Get(long id) => EntityQueryable.SingleOrDefault(rd => rd.Id == id);

    public List<City> GetAll() => EntityQueryable.ToList();

    #endregion
}