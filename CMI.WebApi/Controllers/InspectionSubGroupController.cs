using CMI.Service.HelperClasses;
using CMI.WebApi.HelperClasses;
using FIS.Tools.Exceptions;
using FIS.Tools.ORM_Helper.Models;

namespace CMI.WebApi.Controllers;
/// <summary>
/// زیرگروه بازرسی
/// </summary>
//[AuthenticationCheck]
[Route("api/cmi/[controller]")]
[ApiController]
public class InspectionSubGroupController : WebAPI_Controller<InspectionSubGroup, CmiDataContext, InspectionSubGroupRepository, IInspectionSubGroupService>
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Initialize the controller
    /// </summary>
    /// <param name="service">The service object</param>
    /// <param name="mapper">The mapper object</param>
    public InspectionSubGroupController(IInspectionSubGroupService service, IMapper mapper) : base(service, true)
    {
        _mapper = mapper;
    }

    // *********************************************************************** Get

    /// <summary>
    /// جستجوی در لیست
    /// </summary>
    /// <returns>برگشت اطلاعات جستجو</returns>
    [HttpPost]
    [Route("GetList")]
    [AccessPermissionCheck(Roles = new string[] { Roles.Super_Admin, Roles.System_Admin, Roles.Supervisor_Admin })]
    public IActionResult GetList()
    {
        return ProcessJson(() =>
        {
            var gridSearchFilter = Request.GetEncryptedData<ZimeGridSearchFilter>();
            var pageParams = gridSearchFilter!.ConvertToFilterParams(15, 0);
            var records = Service.SearchRecords(pageParams);

            return new ZimaSimpleGridData<OutInspectionSubGroup>
            {
                MetaData = new ZimaGridMetaData
                {
                    Page = pageParams.PageNumber,
                    PageSize = pageParams.PageSize,
                    TotalCount = pageParams.TotalCount
                },
                Data = _mapper.Map<List<InspectionSubGroup>, List<OutInspectionSubGroup>>(records).ToArray()
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
    [AccessPermissionCheck(Roles = new string[] { Roles.Super_Admin, Roles.System_Admin, Roles.Supervisor_Admin })]
    public IActionResult Get(long id)
    {
        return ProcessJson(() => _mapper.Map<InspectionSubGroup?, OutInspectionSubGroup>(Service.Get(id)));
    }

    /// <summary>
    /// دریافت اطلاعات رکورد - به همراه چک کردن رد پاهای رکورد
    /// </summary>
    /// <param name="id">شناسه رکورد</param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetWithIsUsedInOtherEntities/{id:long:min(1)}")]
    [AccessPermissionCheck(Roles = new string[] { Roles.Super_Admin, Roles.System_Admin, Roles.Supervisor_Admin })]
    public IActionResult GetWithIsUsedInOtherEntities(long id)
    {
        return ProcessJson(() => _mapper.Map<InspectionSubGroup?, OutInspectionSubGroup>(Service.GetWithIsUsedInOtherEntities(id)));
    }

    // *********************************************************************** Add

    /// <summary>
    /// ثبت اطلاعات
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("Post")]
    [AccessPermissionCheck(Roles = new string[] { Roles.Super_Admin, Roles.System_Admin, Roles.Supervisor_Admin })]
    public IActionResult Post()
    {
        return ProcessJson(() =>
        {
            var inputData = Request.GetAndValidateEncryptedData<InInspectionSubGroup>();
            var entity = _mapper.Map<InInspectionSubGroup, InspectionSubGroup>(inputData!);
            return Service.Add(entity);
        }, usePureResponse: true);
    }

    // *********************************************************************** Update

    /// <summary>
    /// ویرایش اطلاعات
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("Update")]
    [AccessPermissionCheck(Roles = new string[] { Roles.Super_Admin, Roles.System_Admin, Roles.Supervisor_Admin })]
    public IActionResult Update()
    {
        return ProcessJson(() =>
        {
            var inputData = Request.GetAndValidateEncryptedData<InInspectionSubGroup>();
            Service.UpdateRecord(_mapper.Map<InInspectionSubGroup, InspectionSubGroup>(inputData));
        });
    }

    // *********************************************************************** Delete

    /// <summary>
    /// حذف رکورد
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("Delete")]
    [AccessPermissionCheck(Roles = new string[] { Roles.Super_Admin, Roles.System_Admin, Roles.Supervisor_Admin })]
    public IActionResult Delete()
    {
        return ProcessJson(() =>
        {
            var inputData = Request.GetAndValidateEncryptedData<InDelete>();
            Service.Delete(inputData!.Id);
        });
    }


    [HttpPost]
    [Route("SearchSubGroupsByGroupIdForLookUp/{groupId}")]
    [AccessPermissionCheck(Roles = new string[] { Roles.Super_Admin, Roles.System_Admin, Roles.Supervisor_Admin })]
    public IActionResult SearchSubGroupsByGroupIdForLookUp(string groupId)
    {
        return ProcessJson(() =>
        {
            var decryptedData = Request.GetEncryptedData<ZimeGridSearchFilter>();

            if (decryptedData == null)
                throw new InformationException(ErrorMessage.InValidInputModel);

            var pageParams = decryptedData.ConvertToFilterParams((int)PageParamsEnum.PageSize, 0);

            pageParams ??= new PageParams();

            pageParams.FilterParams ??= new List<FilterParam>();
            pageParams.FilterParams.Add(new FilterParam() { Value = groupId.ToString(), Key = "groupId", Operator = SearchOperationType.Equal });
            pageParams.FilterParams.Add(new FilterParam() { Value = (true).ToString(), Key = "IsActive", Operator = SearchOperationType.Equal });

            pageParams.SortParams ??= new List<SortParam>();
            pageParams.SortParams.Add(new SortParam
            {
                OrderBy = "code",
                SortOrder = "asc"
            });
            var records = Service.SearchRecords(pageParams);
            var result = _mapper.Map<List<InspectionSubGroup>, List<OutInspectionSubGroup>>(records).ToArray();
            return new ZimaSimpleGridData<OutInspectionSubGroup>
            {
                MetaData = new ZimaGridMetaData
                {
                    Page = pageParams.PageNumber,
                    PageSize = pageParams.PageSize,
                    TotalCount = pageParams.TotalCount
                },
                Data = result
            };
        }, usePureResponse: true);
    }

    [HttpPost]
    [Route("SearchSubGroupsByGroupId/{groupId}")]
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult SearchSubGroupsByGroupId(long groupId)
    {
        return ProcessJson(() =>
        {
            var decryptedData = Request.GetEncryptedData<ZimaAutoCompleteSearchFilter>();

            if (decryptedData == null)
                throw new InformationException(ErrorMessage.InValidInputModel);

            var outSubGroupList = _mapper.Map<List<InspectionSubGroup>, List<OutInspectionSubGroup>>(Service.SearchInspectionSubGroupsByGroupId(decryptedData.SearchTerm, groupId));
            var result = AfraHelper.GetZimaAutoCompleteRecords(outSubGroupList, u => u.Title, u => u.Id.ToString());

            return result;
        }, usePureResponse: true);
    }
}