namespace CMI.Service.Classes
{
    /// <summary>
    /// سطوح
    /// </summary>
    public class LevelByHatefService : BaseService<LevelByHatef, CmiDataContext, LevelByHatefRepository>, ILevelByHatefService
    {
        // Events.
        public LevelByHatefService(CmiDataContext dataContext, IServiceLocator repositoryLocator) : base(dataContext, repositoryLocator)
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

        public LevelByHatef? Get(long id)
        {
            var entity = EntityRepository.Get(id);

            if (entity == null)
                throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
            return entity;
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
        #endregion
    }
}