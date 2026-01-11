using CMI.Service.HelperClasses;
using FIS.Tools.Exceptions;
using Microsoft.AspNetCore.StaticFiles;

namespace CMI.WebApi.Controllers
{
    /// <summary>
    /// Attahcment
    /// </summary>
    //[AuthenticationCheck]
    [Route("api/cmi/[controller]")]
    [ApiController]
    public class AttachmentController : WebAPI_Controller<Attachment, CmiDataContext, AttachmentRepository, IAttachmentService>
    {
        // Variables. 
        private readonly IMapper _mapper;

        // Events. 
        /// <summary>
        /// Initialize the controller
        /// </summary>
        /// <param name="service">The service object</param>
        /// <param name="mapper">The mapper object</param>
        public AttachmentController(IAttachmentService service, IMapper mapper) : base(service, true)
        {
            _mapper = mapper;
        }

        // Web APIs.
        /// <summary>
        /// جستجوی در لیست
        /// </summary>
        /// <returns>برگشت اطلاعات جستجو</returns>

        // downloads
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InformationException"></exception>
        [HttpGet("{id}")]
        [Route("DownloadFirst/{id}")]
        //[AccessPermissionCheck(Roles = [Roles.Supervisor_Admin, Roles.System_Admin, Roles.Audit_Committee, Roles.Deputy_Office, Roles.Department_Head, Roles.Auditor])]
        public IActionResult DownloadFirst(long id)
        {
            return ProcessStream(() =>
            {
                var attachment = Service.GetAttachment(id, TableEnum.Student).FirstOrDefault();
                if (attachment == null)
                    throw new InformationException(ErrorMessage.NotFoundAttachment);
                var sanaFile = ExternalServices.GetSana().GetFile(attachment.SanaId.ToString());
                if (!(sanaFile == null || sanaFile.Data == null || sanaFile.IsSuccessed == false))
                    new FileExtensionContentTypeProvider().TryGetContentType(Path.GetFileName(attachment.FileName)!, out var contentType);
                return File(sanaFile.Data, "application/octet-stream", attachment.FileName);

            });
        }
        [HttpGet("{id}")]
        [Route("Download/{id}")]
        //[AccessPermissionCheck(Roles = [Roles.Supervisor_Admin, Roles.System_Admin, Roles.Audit_Committee, Roles.Deputy_Office, Roles.Department_Head, Roles.Auditor])]
        public IActionResult Download(long id)
        {
            return ProcessStream(() =>
            {
                var attachment = Service.GetAttachment(id);
                if (attachment == null)
                    throw new InformationException(ErrorMessage.NotFoundAttachment);
                var sanaFile = ExternalServices.GetSana().GetFile(attachment.SanaId.ToString());
                if (!(sanaFile == null || sanaFile.Data == null || sanaFile.IsSuccessed == false))
                    new FileExtensionContentTypeProvider().TryGetContentType(Path.GetFileName(attachment.FileName)!, out var contentType);
                return File(sanaFile.Data, "application/octet-stream", attachment.FileName);

            });
        }
        [HttpPost("{id}")]
        [Route("DeleteAttachmentWithTableId/{id}")]
        //[AccessPermissionCheck(Roles = [Roles.Super_Admin, Roles.System_Admin, Roles.Supervisor_Admin, Roles.Department_Head])]
        public IActionResult DeleteAttachmentWithTableId(long id)
        {
            return ProcessJson(() =>
            {
                var decryptedData = Request.GetEncryptedData<ZimaAutoCompleteSearchFilter>();
                if (decryptedData == null)
                    throw new InformationException(ErrorMessage.InValidInputModel);
                var entities = Service.GetAttachment(id, TableEnum.Student);

                var sana = ExternalServices.GetSana();
                if (entities != null)
                    entities.ForEach(entity =>
                    {
                        var result = sana.DeleteFile(CmiDataContext.AppName, entity.SanaId);
                        if (result == null || result.StatusCode != System.Net.HttpStatusCode.OK && !result.IsSuccessed)
                        {
                            throw new InformationException("خطا در پاک کردن عکس");
                        }
                        Service.Delete(entity);
                    });

                return Ok();

            }, usePureResponse: true);
        }
        [HttpPost("{attachmentId}")]
        [Route("DeleteAttachmentWithAttachmentId/{attachmentId}")]
        //[AccessPermissionCheck(Roles = [Roles.Super_Admin, Roles.System_Admin, Roles.Supervisor_Admin, Roles.Department_Head])]
        public IActionResult DeleteAttachmentWithAttachmentId(long attachmentId)
        {
            return ProcessJson(() =>
            {
                var decryptedData = Request.GetEncryptedData<ZimaAutoCompleteSearchFilter>();
                if (decryptedData == null)
                    throw new InformationException(ErrorMessage.InValidInputModel);
                var entity = Service.GetAttachment(attachmentId);

                var sana = ExternalServices.GetSana();

                var result = sana.DeleteFile(CmiDataContext.AppName, entity.SanaId);

                if (result == null || result.StatusCode != System.Net.HttpStatusCode.OK && !result.IsSuccessed)
                {
                    throw new InformationException("خطا در پاک کردن عکس");
                }
                Service.Delete(entity);
                return Ok();

            }, usePureResponse: true);
        }
    }
}