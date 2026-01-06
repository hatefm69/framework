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
        CreateMap<InStudent, Student>()
            .ForMember(x => x.BirthDate, d => d.MapFrom(x => x.BirthDate.ToPersianDate()))
            ;
        ;
        CreateMap<InCity, City>();
        CreateMap<InFamilyRelationship, FamilyRelationship>()
            .ForMember(x => x.FullName, d => d.MapFrom(x => x.familyRelationshipfullName));
        ;
        			CreateMap<InAttachment, Attachment>();
// @#$(Auto Code Generator Part)-#001#

        #endregion

        #region Response DTOs

        CreateMap<InspectionGroup, OutInspectionGroup>();
        CreateMap<InspectionSubGroup, OutInspectionSubGroup>();
        CreateMap<LevelByHatef, OutLevelByHatef>();
        CreateMap<Student, Dto.Response.OutStudent>()
            .ForMember(x => x.FullName, d => d.MapFrom(x => $"{x.FirstName} {x.LastName}"))
            .ForMember(x => x.BirthDate, d => d.MapFrom(x => x.BirthDate.ToGorgianDate()))
            .ForMember(x => x.familyRelationshipsTableData, d => d.MapFrom(x => x.FamilyRelationships.ToList()
            .Select(x => new ZimaTableColumn[]
            {
                 new() { Value = x.FullName.ToString() , Name = "familyRelationshipfullName" },
                new (){Value=x.FamilyRelationshipId.ToString(),Name="familyRelationshipId"},
                 new() { Value = ((FamilyRelationshipEnum) x.FamilyRelationshipId).GetDescription() , Name = "familyRelationshipTitle" },
            })));

        CreateMap<City, OutCity>();
        CreateMap<FamilyRelationship, OutFamilyRelationship>();

        			CreateMap<Attachment, OutAttachment>();
// @#$(Auto Code Generator Part)-#002#

        #endregion
    }
}