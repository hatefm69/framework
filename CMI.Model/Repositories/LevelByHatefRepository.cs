namespace CMI.Model.Repositories
{
    /// <summary>
    /// سطوح
    /// </summary>
    public class LevelByHatefRepository : Repository<LevelByHatef, CmiDataContext>
    {
        // Events.
        public LevelByHatefRepository() { }

        public LevelByHatefRepository(CmiDataContext dataContext, IServiceLocator entityLocator) : base(dataContext, entityLocator) { }

        #region Private Functions.

        #endregion

        #region Public Functions.

        public LevelByHatef? Get(long id) => EntityQueryable.SingleOrDefault(rd => rd.Id == id);

        public List<LevelByHatef> GetAll() => EntityQueryable.ToList();
        public List<LevelByHatef> GetAllActivesBySearchTerms(string searchTerm)
        {
            return EntityQueryable.Where(x => x.Title.Contains(searchTerm)).OrderByDescending(x => x.Id).ToList();
        }

        #endregion
    }
}