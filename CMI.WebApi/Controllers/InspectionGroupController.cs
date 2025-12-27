using CMI.Service.HelperClasses;
using CMI.WebApi.HelperClasses;
using FIS.Tools.Exceptions;
using FIS.Tools.ORM_Helper.Models;

namespace CMI.WebApi.Controllers;
/// <summary>
/// گروه بازرسی
/// </summary>
//[AuthenticationCheck]
[Route("api/cmi/[controller]")]
[ApiController]
public class InspectionGroupController : WebAPI_Controller<InspectionGroup, CmiDataContext, InspectionGroupRepository, IInspectionGroupService>
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Initialize the controller
    /// </summary>
    /// <param name="service">The service object</param>
    /// <param name="mapper">The mapper object</param>
    public InspectionGroupController(IInspectionGroupService service, IMapper mapper) : base(service, true)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// جستجوی در لیست
    /// </summary>
    /// <returns>برگشت اطلاعات جستجو</returns>
    [HttpPost]
    [Route("GetList")]
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult GetList()
    {
        return ProcessJson(() =>
        {
            var gridSearchFilter = Request.GetEncryptedData<ZimeGridSearchFilter>();
            var pageParams = gridSearchFilter!.ConvertToFilterParams(15, 0);
            var records = Service.SearchRecords(pageParams);

            return new ZimaSimpleGridData<OutInspectionGroup>
            {
                MetaData = new ZimaGridMetaData
                {
                    Page = pageParams.PageNumber,
                    PageSize = pageParams.PageSize,
                    TotalCount = pageParams.TotalCount
                },
                Data = [.. _mapper.Map<List<InspectionGroup>, List<OutInspectionGroup>>(records)]
            };
        }, usePureResponse: true);
    }

    /// <summary>
    /// جستجوی در لیست
    /// </summary>
    /// <returns>برگشت اطلاعات جستجو</returns>
    [HttpPost]
    [Route("GetAllReferralGroups")]
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult GetAllReferralGroups()
    {
        return ProcessJson(() =>
        {
            var gridSearchFilter = Request.GetEncryptedData<ZimeGridSearchFilter>();
            var pageParams = gridSearchFilter!.ConvertToFilterParams(15, 0);
            var records = Service.GetAllReferralGroups(pageParams);

            return new ZimaSimpleGridData<IdTitle>
            {
                MetaData = new ZimaGridMetaData
                {
                    Page = pageParams.PageNumber,
                    PageSize = pageParams.PageSize,
                    TotalCount = pageParams.TotalCount
                },
                Data = [.. records]
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
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult Get(long id)
    {
        return ProcessJson(() => _mapper.Map<InspectionGroup?, OutInspectionGroup>(Service.Get(id)));
    }

    /// <summary>
    /// دریافت اطلاعات رکورد - به همراه چک کردن رد پاهای رکورد
    /// </summary>
    /// <param name="id">شناسه رکورد</param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetWithIsUsedInOtherEntities/{id:long:min(1)}")]
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult GetWithIsUsedInOtherEntities(long id)
    {
        return ProcessJson(() => _mapper.Map<InspectionGroup?, OutInspectionGroup>(Service.GetWithIsUsedInOtherEntities(id)));
    }

    /// <summary>
    /// دریافت رکوردها برای اتو کامپلیت
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("GetAllForAutoComplete")]
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult GetAllForAutoComplete()
    {
        return ProcessJson(() =>
        {
            var inputData = Request.GetEncryptedData<ZimaAutoCompleteSearchFilter>();
            return Service.GetAllForAutoComplete(inputData!.SearchTerm);
        }, usePureResponse: true);
    }

    /// <summary>
    /// ثبت اطلاعات
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("Post")]
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult Post() => ProcessJson(() =>
    {
        var decryptedData = Request.GetAndValidateEncryptedData<InInspectionGroup>();
        return Service.Add(_mapper.Map<InInspectionGroup, InspectionGroup>(decryptedData!));
    }, usePureResponse: true);

    /// <summary>
    /// ویرایش اطلاعات
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("Update")]
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult Update()
    {
        return ProcessJson(() =>
        {
            var inputData = Request.GetAndValidateEncryptedData<InInspectionGroup>();
            Service.UpdateRecord(_mapper.Map<InInspectionGroup, InspectionGroup>(inputData!));
        });
    }

    /// <summary>
    /// حذف رکورد
    /// </summary>
    /// <param name="id">شناسه رکورد</param>
    /// <returns></returns>
    [HttpPost]
    [Route("Delete")]
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult Delete()
    {
        return ProcessJson(() =>
        {
            var inputData = Request.GetAndValidateEncryptedData<InDelete>();
            Service.Delete(inputData!.Id);
        });
    }


    /// <summary>
    /// جستجوی گروه های فعال
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InformationException"></exception>
    [HttpPost]
    [Route("SearchActiveGroups")]
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult SearchActiveGroups()
    {
        return ProcessJson(() =>
        {
            var decryptedData = Request.GetEncryptedData<ZimaAutoCompleteSearchFilter>();

            if (decryptedData == null)
                throw new InformationException(ErrorMessage.InValidInputModel);

            var list = _mapper.Map<List<InspectionGroup>, List<OutInspectionGroup>>(Service.GetActiveInspectionGroups(decryptedData.SearchTerm));
            var result = AfraHelper.GetZimaAutoCompleteRecords(list, u => u.Title, u => u.Id.ToString());

            return result;
        }, usePureResponse: true);
    }

    [HttpPost]
    [Route("SearchGroups")]
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult SearchGroups()
    {
        return ProcessJson(() =>
        {
            var decryptedData = Request.GetEncryptedData<ZimaAutoCompleteSearchFilter>();

            if (decryptedData == null)
                throw new InformationException(ErrorMessage.InValidInputModel);

            var list = _mapper.Map<List<InspectionGroup>, List<OutInspectionGroup>>(Service.GetInspectionGroups(decryptedData.SearchTerm));
            var result = AfraHelper.GetZimaAutoCompleteRecords(list, u => u.Title, u => u.Id.ToString());

            return result;
        }, usePureResponse: true);
    }



    [HttpPost]
    [Route("GetListForLookUp")]
    [CustomAccessPermissionCheck(RolesProviderType = typeof(AdminRoles))]
    public IActionResult GetListForLookUp()
    {
        return ProcessJson(() =>
        {
            var decryptedData = Request.GetEncryptedData<ZimeGridSearchFilter>();

            if (decryptedData == null)
                throw new InformationException(ErrorMessage.InValidInputModel);

            var pageParams = decryptedData.ConvertToFilterParams((int)PageParamsEnum.PageSize, 0);

            pageParams ??= new PageParams();

            pageParams.FilterParams ??= new List<FilterParam>();
            pageParams.FilterParams.Add(new FilterParam() { Value = (true).ToString(), Key = "IsActive", Operator = SearchOperationType.Equal });

            pageParams.SortParams ??= new List<SortParam>();
            pageParams.SortParams.Add(new SortParam
            {
                OrderBy = "code",
                SortOrder = "asc"
            });
            var records = Service.SearchRecords(pageParams);
            var result = _mapper.Map<List<InspectionGroup>, List<OutInspectionGroup>>(records).ToArray();
            return new ZimaSimpleGridData<OutInspectionGroup>
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
}