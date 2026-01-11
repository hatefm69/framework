namespace CMI.Service.Classes
{
    /// <summary>
    /// Attahcment
    /// </summary>
    public class AttachmentService : BaseService<Attachment, CmiDataContext, AttachmentRepository>, IAttachmentService
    {
        // Events.
        public AttachmentService(CmiDataContext dataContext, IServiceLocator repositoryLocator) : base(dataContext, repositoryLocator)
        {
            dataContext.GetUserInformaion = () => new UserInformation
            {
                Identity = Request.GetUserName(),
                IP = Request.GetUserIp()
            };
        }

        #region Other Functinos.

        public Attachment? GetAttachment(long id)
        {
            var entity = EntityRepository.GetAttachment(id);
            if (entity == null)
                throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
            return entity;
        }
        public List<Attachment> GetAttachment(long id, TableEnum tableEnum)
        {
            var entities = EntityRepository.GetAttachment(id, tableEnum);
            if (entities == null)
                throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
            return entities;
        }

        public void Delete(Attachment attachment)
        {
            EntityRepository.Remove(attachment);
        }

        public override List<Attachment> SearchRecords(PageParams pageParams, ExpressionBindType expressionBindType = ExpressionBindType.AndAlso)
        {
            var tableId = (TableEnum)Enum.Parse(typeof(TableEnum), pageParams.FilterParams.First().Key);

            return EntityRepository.SearchRecords(pageParams, long.Parse(pageParams.FilterParams.First().Value),
                tableId);
        }
        #endregion

        #region Web API Function.


        #endregion
    }
}