namespace CMI.Model.Mappings;

/// <summary>
/// دانش آموز
/// </summary>
public class StudentMap : EntityMap<Student>
{
    // Events.
    public StudentMap()
    {
        MappingConfigurations = (builder) =>
        {
            builder.ToTable("STUDENT");
            builder.Property(pr => pr.Id).HasColumnName("ID").IsRequired();
            builder.Property(pr => pr.FirstName).HasColumnName("FIRST_NAME").IsRequired().HasMaxLength(50);
            builder.Property(pr => pr.LastName).HasColumnName("LAST_NAME").IsRequired().HasMaxLength(50);
            builder.Property(pr => pr.LevelId).HasColumnName("LEVEL_ID").IsRequired();
            builder.Property(pr => pr.CityId).HasColumnName("CITY_ID").IsRequired();

            // Indexes.
            builder.HasKey(pr => pr.Id);


        };
    }
}
