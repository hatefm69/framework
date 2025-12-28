namespace CMI.Service.Classes;

/// <summary>
/// شهر
/// </summary>
public class CityService : BaseService<City, CmiDataContext, CityRepository>, ICityService
{
    // Events.
    public CityService(CmiDataContext dataContext, IServiceLocator repositoryLocator) : base(dataContext, repositoryLocator)
    {
        dataContext.GetUserInformaion = () => new UserInformation
        {
            Identity = Request.GetUserName(),
            IP = Request.GetUserIp()
        };
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

    public City? Get(long id)
    {
        var entity = EntityRepository.Get(id);

        if (entity == null)
            throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
        return entity;
    }
    public ICollection<City> GetAll() => EntityRepository.GetAll();

    #endregion
}