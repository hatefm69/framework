namespace CMI.WebApi.Controllers
{
    /// <summary>
    /// شهر
    /// </summary>
    //[AuthenticationCheck]
    [Route("api/cmi/[controller]")]
    [ApiController]
    public class CityController : WebAPI_Controller<City, CmiDataContext, CityRepository, ICityService>
    {
        // Variables. 
        private readonly IMapper _mapper;

        // Events. 
        /// <summary>
        /// Initialize the controller
        /// </summary>
        /// <param name="service">The service object</param>
        /// <param name="mapper">The mapper object</param>
        public CityController(ICityService service, IMapper mapper) : base(service, true)
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
                var records = Service.GetAll();

                return new ZimaSimpleGridData<City>
                {

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
            return ProcessJson(() => _mapper.Map<City?, OutCity>(Service.Get(id)));
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
                var inputData = Request.GetAndValidateEncryptedData<InCity>();
                var entity = _mapper.Map<InCity, City>(inputData);

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
                var inputData = Request.GetAndValidateEncryptedData<InCity>();

                Service.UpdateRecord(_mapper.Map<InCity, City>(inputData));
            });
        }
        [HttpPost()]
        [Route("GetAllCityRemoteDropDown")]
        //[AccessPermissionCheck(Roles = new string[] { "admin" })]
        public IActionResult GetAllCityRemoteDropDown()
        {
            return ProcessJson(() =>
            {
                var zimaRemoteDropDownItems = new List<ZimaRemoteDropDownItem>();
                var list = Service.GetAllCityRemoteDropdown();
                list = list.OrderBy(x => x.Name).ToArray();
                return list;
            }, usePureResponse: true);
        }
    }
}