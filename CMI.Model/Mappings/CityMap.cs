namespace CMI.Model.Mappings;

/// <summary>
/// شهر
/// </summary>
public class CityMap : EntityMap<City>
{
    // Events.
    public CityMap()
    {
        MappingConfigurations = (builder) =>
        {
            builder.ToTable("CITY");
            builder.Property(pr => pr.Id).HasColumnName("ID").IsRequired();
            builder.Property(pr => pr.Title).HasColumnName("TITLE").IsRequired().HasMaxLength(50);

            // Indexes.
            builder.HasKey(pr => pr.Id);
            // Foreign Keys.
            builder.HasMany(pr => pr.Students).WithOne(pr => pr.City).HasForeignKey(pr => pr.CityId).OnDelete(DeleteBehavior.Restrict);


        };
    }
}
