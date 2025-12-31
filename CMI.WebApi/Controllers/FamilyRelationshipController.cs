namespace CMI.WebApi.Controllers;

/// <summary>
/// والدین
/// </summary>
//[AuthenticationCheck]
[Route("api/cmi/[controller]")]
[ApiController]
public class FamilyRelationshipController : WebAPI_Controller<FamilyRelationship, CmiDataContext, FamilyRelationshipRepository, IFamilyRelationshipService>
{
    // Variables. 
    private readonly IMapper _mapper;

    // Events. 
    /// <summary>
    /// Initialize the controller
    /// </summary>
    /// <param name="service">The service object</param>
    /// <param name="mapper">The mapper object</param>
    public FamilyRelationshipController(IFamilyRelationshipService service, IMapper mapper) : base(service)
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

            return new ZimaSimpleGridData<OutFamilyRelationship>
            {
                MetaData = new ZimaGridMetaData
                {
                    Page = pageParams.PageNumber,
                    PageSize = pageParams.PageSize,
                    TotalCount = pageParams.TotalCount
                },
                Data = _mapper.Map<List<FamilyRelationship>, List<OutFamilyRelationship>>(records).ToArray()
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
        return ProcessJson(() => _mapper.Map<FamilyRelationship?, OutFamilyRelationship>(Service.Get(id)));
    }

    /// <summary>
    /// حذف رکورد
    /// </summary>
    /// <param name="id">شناسه رکورد</param>
    /// <returns></returns>
    [HttpGet]
    [Route("Delete/{id:long:min(1)}")]
    //[AccessPermissionCheck(Roles = new string[] { "admin" })]
    public IActionResult Delete(long id)
    {
        return ProcessJson(() => Service.Delete(id));
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
            var inputData = Request.GetAndValidateEncryptedData<InFamilyRelationship>();
            var entity = _mapper.Map<InFamilyRelationship, FamilyRelationship>(inputData);

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
            var inputData = Request.GetAndValidateEncryptedData<InFamilyRelationship>();

            Service.UpdateRecord(_mapper.Map<InFamilyRelationship, FamilyRelationship>(inputData));
        });
    }
}