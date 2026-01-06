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
        [HttpPost]
        [Route("GetList")]
        //[AccessPermissionCheck(Roles = new string[] { "admin" })]
        public IActionResult GetList()
        {
            return ProcessJson(() =>
            {
                var gridSearchFilter = Request.GetEncryptedData<ZimeGridSearchFilter>();
                var pageParams = gridSearchFilter.ConvertToFilterParams(15, 0);
                var records = Service.SearchRecords(pageParams);

                return new ZimaSimpleGridData<OutAttachment>
                {
                    MetaData = new ZimaGridMetaData
                    {
                        Page = pageParams.PageNumber,
                        PageSize = pageParams.PageSize,
                        TotalCount = pageParams.TotalCount
                    },
                    Data = _mapper.Map<List<Attachment>, List<OutAttachment>>(records).ToArray()
                };
            }, usePureResponse: true);
        }

        /// <summary>
        /// ثبت اطلاعات
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Post")]
        //[AccessPermissionCheck(Roles = new string[] { "admin" })]
        public IActionResult Post()
        {
            return ProcessJson(() =>
            {
                var inputData = Request.GetAndValidateEncryptedData<InAttachment>();
                var entity = _mapper.Map<InAttachment, Attachment>(inputData);

                //entity.Id = Guid.NewGuid();
                Service.AddRecord(entity);
            });
        }

        /// <summary>
        /// ویرایش اطلاعات
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        //[AccessPermissionCheck(Roles = new string[] { "admin" })]
        public IActionResult Update()
        {
            return ProcessJson(() =>
            {
                var inputData = Request.GetAndValidateEncryptedData<InAttachment>();

                Service.UpdateRecord(_mapper.Map<InAttachment, Attachment>(inputData));
            });
        }
        // downloads
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InformationException"></exception>
        [HttpGet("{id}")]
        [Route("Download/{id}")]
        //[AccessPermissionCheck(Roles = [Roles.Supervisor_Admin, Roles.System_Admin, Roles.Audit_Committee, Roles.Deputy_Office, Roles.Department_Head, Roles.Auditor])]
        public IActionResult Download(long id)
        {
            return ProcessStream(() =>
            {
                var attachment = Service.GetAttachment(id, TableEnum.Student);
                var sanaFile = ExternalServices.GetSana().GetFile(attachment.SanaId.ToString());
                if (!(sanaFile == null || sanaFile.Data == null || sanaFile.IsSuccessed == false))
                    new FileExtensionContentTypeProvider().TryGetContentType(Path.GetFileName(attachment.FileName)!, out var contentType);
                return File(sanaFile.Data, "application/octet-stream", attachment.FileName);

            });
        }
        [HttpPost("{id}")]
        [Route("Delete/{id}")]
        //[AccessPermissionCheck(Roles = [Roles.Super_Admin, Roles.System_Admin, Roles.Supervisor_Admin, Roles.Department_Head])]
        public IActionResult Delete(long id)
        {
            return ProcessJson(() =>
            {
                var decryptedData = Request.GetEncryptedData<ZimaAutoCompleteSearchFilter>();
                if (decryptedData == null)
                    throw new InformationException(ErrorMessage.InValidInputModel);
                var entity = Service.GetAttachment(id, TableEnum.Student);

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