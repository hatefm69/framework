namespace CMI.Model.Repositories
{
    /// <summary>
    /// Attahcment
    /// </summary>
    public class AttachmentRepository : Repository<Attachment, CmiDataContext>
    {
        // Events.
        public AttachmentRepository() { }

        public AttachmentRepository(CmiDataContext dataContext, IServiceLocator entityLocator) : base(dataContext, entityLocator) { }

        #region Private Functions.

        #endregion

        #region Public Functions.

        public List<Attachment> GetAll() => EntityQueryable.ToList();
        public Attachment GetAttachment(long id) => EntityQueryable.FirstOrDefault(x => x.Id == id);
        public Attachment GetAttachment(long id, TableEnum tableEnum) => EntityQueryable.FirstOrDefault(x => x.RecordId == id && x.TableId == tableEnum);
        public List<Attachment> GetAttachments(long recordId) => EntityQueryable.Where(x => x.RecordId == recordId).ToList();
        #endregion
    }
}