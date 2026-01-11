using CMI.Service.Classes;

namespace CMI.WebApi.Controllers;

/// <summary>
/// معلم
/// </summary>
//[AuthenticationCheck]
[Route("api/cmi/[controller]")]
[ApiController]
public class TeacherController : WebAPI_Controller<Teacher, CmiDataContext, TeacherRepository, ITeacherService>
{
    // Variables. 
    private readonly IMapper _mapper;

    // Events. 
    /// <summary>
    /// Initialize the controller
    /// </summary>
    /// <param name="service">The service object</param>
    /// <param name="mapper">The mapper object</param>
    public TeacherController(ITeacherService service, IMapper mapper) : base(service, true)
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

            return new ZimaSimpleGridData<Model.Models.OutTeacher>
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
        return ProcessJson(() => _mapper.Map<TeacherWithFamilyRelation?, Dto.Response.OutTeacher>(Service.Get(id)), usePureResponse: true);
    }

    [HttpGet]
    [Route("GetWithAttachment/{id:long:min(1)}")]
    //[AccessPermissionCheck(Roles = new string[] { "admin" })]
    public IActionResult GetWithAttachment(long id)
    {
        return ProcessJson(() => _mapper.Map<TeacherWithAttachment?, OutTeacherWithAttachment>(Service.GetWithAttachment(id)));
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
                var inputData = Request.GetAndValidateEncryptedData<InTeacher>();
                var entity = _mapper.Map<InTeacher, TeacherWithFamilyRelation>(inputData);

                Service.AddRecord(entity);
            }
            else
            {
                var inputData = Request.GetAndValidateEncryptedFilesData<InTeacher>();
                var entity = _mapper.Map<InTeacher, TeacherWithFamilyRelation>(inputData.Data);
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
        //    var inputData = Request.GetAndValidateEncryptedData<InTeacher>();

        //    Service.UpdateRecord(_mapper.Map<InTeacher, Teacher>(inputData));
        //});


        return ProcessJson(() =>
        {
            if (Request.IsContentJson())
            {
                var inputData = Request.GetAndValidateEncryptedData<InTeacher>();
                var entity = _mapper.Map<InTeacher, TeacherWithFamilyRelation>(inputData);

                Service.UpdateRecord(entity);
            }
            else
            {
                var inputData = Request.GetAndValidateEncryptedFilesData<InTeacher>();
                var entity = _mapper.Map<InTeacher, TeacherWithFamilyRelation>(inputData.Data);
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
                Key = nameof(TableEnum.Teacher)
            });

            var records = attachmentService.SearchRecords(pageParams);

            return records.Select(x => new ZimaTableColumn[]
            {
                    new() { Value = x.FileName.ToString() , Name= nameof(x.FileName).AsCamelCase() },
                    new() { Value = x.Id.ToString() , Name = nameof(x.Id).AsCamelCase() },
            }).ToList();

        }, usePureResponse: true);
    }
}

