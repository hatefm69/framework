

namespace CMI.Service.Interfaces
{
    /// <summary>
    /// Attahcment
    /// </summary>
    public interface IAttachmentService : IBaseService<Attachment, CmiDataContext, AttachmentRepository>
    {
        void Delete(Attachment attachment);
        Attachment? GetAttachment(long id);
        List<Attachment>? GetAttachment(long id, TableEnum tableEnum);
    }
}
