

namespace CMI.Service.Interfaces;

/// <summary>
/// شهر
/// </summary>
public interface ICityService : IBaseService<City, CmiDataContext, CityRepository>
{
    // Functions.
    void Delete(long id);
    City? Get(long id);
    ICollection<City> GetAll();
    ZimaRemoteDropDownRecord[] GetAllCityRemoteDropdown();
}
