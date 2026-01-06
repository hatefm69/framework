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
        public Attachment? GetAttachment(long id, TableEnum tableEnum)
        {
            var entity = EntityRepository.GetAttachment(id, tableEnum);
            if (entity == null)
                throw new InformationException("داده ای با شناسه ارسالی پیدا نشد");
            return entity;
        }

        public void Delete(Attachment attachment)
        {
            EntityRepository.Remove(attachment);
        }
        #endregion

        #region Web API Function.


        #endregion
    }
}