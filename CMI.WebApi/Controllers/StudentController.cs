using CMI.Service.Classes;
using CMI.Service.Model;
using FIS.Tools.Exceptions;

namespace CMI.WebApi.Controllers;

/// <summary>
/// دانش آموز
/// </summary>
//[AuthenticationCheck]
[Route("api/cmi/[controller]")]
[ApiController]
public class StudentController : WebAPI_Controller<Student, CmiDataContext, StudentRepository, IStudentService>
{
    // Variables. 
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _hostingEnvironment;

    // Events. 
    /// <summary>
    /// Initialize the controller
    /// </summary>
    /// <param name="service">The service object</param>
    /// <param name="mapper">The mapper object</param>
    public StudentController(IStudentService service, IMapper mapper, IWebHostEnvironment hostingEnvironment) : base(service, true)
    {
        _mapper = mapper;
        _hostingEnvironment = hostingEnvironment;
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

            return new ZimaSimpleGridData<Model.Models.OutStudent>
            {
                MetaData = new ZimaGridMetaData
                {
                    Page = pageParams.PageNumber,
                    PageSize = pageParams.PageSize,
                    TotalCount = pageParams.TotalCount
                },
                Data = records.ToArray()
            };
        }, usePureResponse: true);
    }

    /// <summary>
    /// دریافت اطلاعات رکورد
    /// </summary>
    /// <param name="id">شناسه رکورد</param>
    /// <returns></returns>
    [HttpGet]
    [Route("Get/{id:long:min(1)}")]
    //[AccessPermissionCheck(Roles = new string[] { "admin" })]
    public IActionResult Get(long id)
    {
        return ProcessJson(() =>
        {
            return _mapper.Map<StudentWithFamilyRelation?, Dto.Response.OutStudent>(Service.Get(id));
        }


        , usePureResponse: true);
    }

    [HttpGet]
    [Route("GetWithAttachment/{id:long:min(1)}")]
    //[AccessPermissionCheck(Roles = new string[] { "admin" })]
    public IActionResult GetWithAttachment(long id)
    {
        return ProcessJson(() => _mapper.Map<StudentWithAttachment?, OutStudentWithAttachment>(Service.GetWithAttachment(id)));
    }

    /// <summary>
    /// حذف رکورد
    /// </summary>
    /// <param name="id">شناسه رکورد</param>
    /// <returns></returns>
    [HttpDelete]
    [Route("Delete")]
    //[AccessPermissionCheck(Roles = new string[] { "admin" })]
    public IActionResult Delete()
    {
        return ProcessJson(() =>
        {
            var inputData = Request.GetAndValidateEncryptedData<InDelete>();
            Service.Delete(inputData!.Id);
        });
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
            if (Request.IsContentJson())
            {
                var inputData = Request.GetAndValidateEncryptedData<InStudent>();
                var entity = _mapper.Map<InStudent, StudentWithFamilyRelation>(inputData);

                Service.AddRecord(entity);
            }
            else
            {
                var inputData = Request.GetAndValidateEncryptedFilesData<InStudent>();
                var entity = _mapper.Map<InStudent, StudentWithFamilyRelation>(inputData.Data);
                Service.AddRecord(entity, inputData.Files);
            }

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
        //return ProcessJson(() =>
        //{
        //    var inputData = Request.GetAndValidateEncryptedData<InStudent>();

        //    Service.UpdateRecord(_mapper.Map<InStudent, Student>(inputData));
        //});


        return ProcessJson(() =>
        {
            if (Request.IsContentJson())
            {
                var inputData = Request.GetAndValidateEncryptedData<InStudent>();
                var entity = _mapper.Map<InStudent, StudentWithFamilyRelation>(inputData);

                Service.UpdateRecord(entity);
            }
            else
            {
                var inputData = Request.GetAndValidateEncryptedFilesData<InStudent>();
                var entity = _mapper.Map<InStudent, StudentWithFamilyRelation>(inputData.Data);
                Service.UpdateRecord(entity, inputData.Files);
            }

        });

    }
    [HttpPost()]
    [Route("GetListAttachments/{id}")]
    public IActionResult GetList(long id)
    {
        return ProcessJson(() =>
        {
            var attachmentService = Service.GetService<Attachment, AttachmentRepository, AttachmentService>();
            var gridSearchFilter = Request.GetEncryptedData<ZimeGridSearchFilter>();
            var pageParams = gridSearchFilter.ConvertToFilterParams(15, 0);
            pageParams.FilterParams = new();
            pageParams.FilterParams.Add(new FIS.Tools.ORM_Helper.Models.FilterParam()
            {
                Value = id.ToString(),
                Key = nameof(TableEnum.Student)
            });

            var records = attachmentService.SearchRecords(pageParams);

            return records.Select(x => new ZimaTableColumn[]
            {
                    new() { Value = x.FileName.ToString() , Name= nameof(x.FileName).AsCamelCase() },

                       new() { Value = ((AttachementCategoryEnum) x.AttachmentCategoryId).GetDescription() , Name = "attachmentCategoryTitle" },


                    new() { Value = x.Id.ToString() , Name = nameof(x.Id).AsCamelCase() },
            }).ToList();

        }, usePureResponse: true);
    }

    [HttpPost("GetAllStudentReportExcel")]
    public IActionResult GetAllStudentReportExcel()
    {
        return ProcessStream(() =>
        {
            var records = Service.GetAll();

            var fileContent = Service.GetCombinedReportExcelFile(records, "دانش آموزان");
            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        });
    }
    /// <summary>
    /// ثبت گروهی فعالیت ها و واحدهای متولی با اکسل
    /// </summary>
    [HttpPost]
    [Route("AddRangeByExcel")]
    //[AccessPermissionCheck(Roles = [Roles.Supervisor_Admin, Roles.System_Admin])]
    public IActionResult AddRangeByExcel()
    {
        return ProcessJson(() =>
        {
            var encryptedData = Request.GetAndValidateEncryptedFilesData<InStudentFromExcel>();
            if (encryptedData == null)
                throw new InformationException("مدل ورودی نامعتبر می باشد");
            Service.AddRangeByExcel(encryptedData.Files);
        });
    }
    /// <summary>
    /// دانلود فایل نمونه اکسل در صفحه افزودن گروهی زیر فعالیت ها 
    /// </summary>
    [HttpGet]
    [Route("DownloadTemplateFileForAddRangeByExcel")]
    //[AccessPermissionCheck(Roles = [Roles.Supervisor_Admin, Roles.System_Admin, Roles.Department_Head, Roles.Deputy_Office, Roles.Auditor, Roles.Audit_Committee])]
    public IActionResult DownloadTemplateFileForAddRangeByExcel()
    {
        return ProcessStream(() =>
        {
            var fileName = "downloadTemplateStudent.xlsx";
            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Content", fileName);
            if (!System.IO.File.Exists(filePath))
                throw new InformationException("فایل نمونه اکسل موجود نیست");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        });
    }
}