namespace CMI.Service.Interfaces
{
    /// <summary>
    /// سطوح
    /// </summary>
    public interface ILevelByHatefService : IBaseService<LevelByHatef, CmiDataContext, LevelByHatefRepository>
    {
        // Functions.
        void Delete(long id);
        LevelByHatef? Get(long id);
    }
}
