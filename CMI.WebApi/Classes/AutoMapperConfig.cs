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
            .ForMember(x => x.BirthDate, d => d.MapFrom(x => x.BirthDate.ToPersianDate()));

        CreateMap<InTeacher, Teacher>()
         .ForMember(x => x.BirthDate, d => d.MapFrom(x => x.BirthDate.ToPersianDate()));

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
            .ForMember(x => x.BirthDate, d => d.MapFrom(x => x.BirthDate.ToGorgianDate()));


        CreateMap<City, OutCity>();
        CreateMap<FamilyRelationship, OutFamilyRelationship>();

        CreateMap<Attachment, OutAttachment>();


        CreateMap<InStudent, StudentWithFamilyRelation>()
            .ForMember(x => x.Student, c => c.MapFrom(x => new InStudent
            {
                BirthDate = x.BirthDate,
                CityId = x.CityId,
                FamilyRelationships = x.FamilyRelationships,
                FirstName = x.FirstName,
                Id = x.Id,
                IsActive = x.IsActive,
                LastName = x.LastName,
                LevelId = x.LevelId,
                Message = x.Message

            }))
            .ForMember(x => x.FamilyRelationships, c => c.MapFrom(x => x.FamilyRelationships));

        CreateMap<StudentWithFamilyRelation, Dto.Response.OutStudent>()
            .ForMember(x => x.IsActive, d => d.MapFrom(c => c.Student.IsActive))
            .ForMember(x => x.CityId, d => d.MapFrom(c => c.Student.CityId))
            .ForMember(x => x.BirthDate, d => d.MapFrom(c => c.Student.BirthDate.ToGorgianDate()))
            .ForMember(x => x.LevelId, d => d.MapFrom(c => c.Student.LevelId))
            .ForMember(x => x.LastName, d => d.MapFrom(c => c.Student.LastName))
            .ForMember(x => x.FirstName, d => d.MapFrom(c => c.Student.FirstName))
            .ForMember(x => x.FullName, d => d.MapFrom(c => $"{c.Student.FirstName} {c.Student.LastName}"))
            .ForMember(x => x.Id, d => d.MapFrom(c => c.Student.Id))
            .ForMember(x => x.LevelTitle, d => d.MapFrom(c => c.Student.Level.Title))
            .ForMember(x => x.FamilyRelationshipsTableData, d => d.MapFrom(c => c.FamilyRelationships.Select(c => new ZimaTableColumn[]
                {
                    new() { Value = c.FullName.ToString() , Name = "familyRelationshipfullName" },
                    new() {Value=c.FamilyRelationshipId.ToString(),Name="familyRelationshipId"},
                    new() { Value = ((FamilyRelationshipEnum) c.FamilyRelationshipId).GetDescription() , Name = "familyRelationshipTitle" },
                }).ToArray()));

        CreateMap<TeacherWithFamilyRelation, Dto.Response.OutTeacher>()
        .ForMember(x => x.IsActive, d => d.MapFrom(c => c.Teacher.IsActive))
        .ForMember(x => x.CityId, d => d.MapFrom(c => c.Teacher.CityId))
        .ForMember(x => x.BirthDate, d => d.MapFrom(c => c.Teacher.BirthDate.ToGorgianDate()))
        .ForMember(x => x.LevelId, d => d.MapFrom(c => c.Teacher.LevelId))
        .ForMember(x => x.LastName, d => d.MapFrom(c => c.Teacher.LastName))
        .ForMember(x => x.FirstName, d => d.MapFrom(c => c.Teacher.FirstName))
        .ForMember(x => x.FullName, d => d.MapFrom(c => $"{c.Teacher.FirstName} {c.Teacher.LastName}"))
        .ForMember(x => x.Id, d => d.MapFrom(c => c.Teacher.Id))
        .ForMember(x => x.LevelTitle, d => d.MapFrom(c => c.Teacher.Level.Title))
        .ForMember(x => x.FamilyRelationshipsTableData, d => d.MapFrom(c => c.FamilyRelationships.Select(c => new ZimaTableColumn[]
            {
                    new() { Value = c.FullName.ToString() , Name = "familyRelationshipfullName" },
                    new() {Value=c.FamilyRelationshipId.ToString(),Name="familyRelationshipId"},
                    new() { Value = ((FamilyRelationshipEnum) c.FamilyRelationshipId).GetDescription() , Name = "familyRelationshipTitle" },
            }).ToArray()));



        CreateMap<InTeacher, TeacherWithFamilyRelation>()
            .ForMember(x => x.Teacher, c => c.MapFrom(x => new InTeacher
            {
                BirthDate = x.BirthDate,
                CityId = x.CityId,
                FamilyRelationships = x.FamilyRelationships,
                FirstName = x.FirstName,
                Id = x.Id,
                IsActive = x.IsActive,
                LastName = x.LastName,
                LevelId = x.LevelId,
                Message = x.Message
            }))
            .ForMember(x => x.FamilyRelationships, c => c.MapFrom(x => x.FamilyRelationships));



        CreateMap<TeacherWithFamilyRelation, Dto.Response.OutTeacher>()
          .ForMember(x => x.IsActive, d => d.MapFrom(c => c.Teacher.IsActive))
          .ForMember(x => x.CityId, d => d.MapFrom(c => c.Teacher.CityId))
          .ForMember(x => x.BirthDate, d => d.MapFrom(c => c.Teacher.BirthDate.ToGorgianDate()))
          .ForMember(x => x.LevelId, d => d.MapFrom(c => c.Teacher.LevelId))
          .ForMember(x => x.LastName, d => d.MapFrom(c => c.Teacher.LastName))
          .ForMember(x => x.FirstName, d => d.MapFrom(c => c.Teacher.FirstName))
          .ForMember(x => x.FullName, d => d.MapFrom(c => $"{c.Teacher.FirstName} {c.Teacher.LastName}"))
          .ForMember(x => x.Id, d => d.MapFrom(c => c.Teacher.Id))
          .ForMember(x => x.LevelTitle, d => d.MapFrom(c => c.Teacher.Level.Title))
          .ForMember(x => x.FamilyRelationshipsTableData, d => d.MapFrom(c => c.FamilyRelationships.Select(c => new ZimaTableColumn[]
              {
                    new() { Value = c.FullName.ToString() , Name = "familyRelationshipfullName" },
                    new() {Value=c.FamilyRelationshipId.ToString(),Name="familyRelationshipId"},
                    new() { Value = ((FamilyRelationshipEnum) c.FamilyRelationshipId).GetDescription() , Name = "familyRelationshipTitle" },
              }).ToArray()));





        // @#$(Auto Code Generator Part)-#002#

        #endregion
    }
}