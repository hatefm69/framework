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
        public List<Attachment> GetAttachment(long id, TableEnum tableEnum) => EntityQueryable.Where(x => x.RecordId == id && x.TableId == tableEnum).ToList();
        public List<Attachment> GetAttachments(long recordId) => EntityQueryable.Where(x => x.RecordId == recordId).ToList();
        public List<Attachment> SearchRecords(PageParams pageParams, long studentId)
        {
            var query = EntityQueryable.AsNoTracking()
                .Where(x => x.TableId == TableEnum.Student && x.RecordId == studentId);
            return query.ToList();
            //pageParams.SortParams = new List<SortParam> { new SortParam { OrderBy = "id", SortOrder = "desc" } };
            //return FilterData(query, pageParams).ToList();
        }
        #endregion
    }
}