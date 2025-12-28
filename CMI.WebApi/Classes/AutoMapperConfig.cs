namespace CMI.WebApi.Classes;

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
        CreateMap<InLevelByHatef, LevelByHatef>();
        CreateMap<InStudent, Student>();
        ;
        CreateMap<InCity, City>();
        // @#$(Auto Code Generator Part)-#001#

        #endregion

        #region Response DTOs

        CreateMap<InspectionGroup, OutInspectionGroup>();
        CreateMap<InspectionSubGroup, OutInspectionSubGroup>();
        CreateMap<LevelByHatef, OutLevelByHatef>();
        CreateMap<Student, Dto.Response.OutStudent>().ForMember(x => x.FullName, d => d.MapFrom(x => $"{x.FirstName} {x.LastName}"));
        ;
        CreateMap<City, OutCity>();
        // @#$(Auto Code Generator Part)-#002#

        #endregion
    }
}