namespace CMI.WebApi.Classes
{
    /// <summary>
    /// The Auto mapper configuration for input and output dto
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        // Events.
        /// <summary>
        /// Configures the request and resposne dtos
        /// </summary>
        public AutoMapperConfig()
        {
            #region Requests DTOs

            CreateMap<InInspectionGroup, InspectionGroup>();
            CreateMap<InInspectionSubGroup, InspectionSubGroup>();
            // @#$(Auto Code Generator Part)-#001#

            #endregion

            #region Response DTOs

            CreateMap<InspectionGroup, OutInspectionGroup>();
            CreateMap<InspectionSubGroup, OutInspectionSubGroup>();
            // @#$(Auto Code Generator Part)-#002#

            #endregion
        }
    }
}