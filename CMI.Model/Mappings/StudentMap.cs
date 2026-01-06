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
            builder.Property(pr => pr.Id).HasColumnName("ID").ValueGeneratedNever().IsRequired();
            builder.Property(pr => pr.FirstName).HasColumnName("FIRST_NAME").IsRequired().HasMaxLength(50);
            builder.Property(pr => pr.LastName).HasColumnName("LAST_NAME").IsRequired().HasMaxLength(50);
            builder.Property(pr => pr.LevelId).HasColumnName("LEVEL_ID").IsRequired();
            builder.Property(pr => pr.CityId).HasColumnName("CITY_ID").IsRequired();
            builder.Property(pr => pr.IsActive).HasColumnName("IS_ACTIVE").IsRequired();
            builder.Property(pr => pr.BirthDate).HasColumnName("BIRTH_DATE").IsRequired();

            // Indexes.
            builder.HasKey(pr => pr.Id);

            //Foreign Keys.
            builder.HasMany(pr => pr.FamilyRelationships).WithOne(pr => pr.Student).HasForeignKey(pr => pr.StudentId).OnDelete(DeleteBehavior.Restrict);

            builder.OwnsMany(builder => builder.EducationalQualification, nc =>
            {
                nc.ToTable("STUDENT_EDUCATIONAL_QUALIFICATION");

                nc.WithOwner()
                .HasForeignKey(x => x.StudentId);

                nc.Property<long>("ID");
                nc.HasKey("ID");
                nc.Property(p => p.Educational)
                   .HasColumnName("EDUCATIONAL")
                   .IsRequired()
                   .HasMaxLength(100);

                nc.OwnsOne(nc => nc.Score, score =>
                {
                    score.Property(p => p.Value)
                   .HasColumnName("EDUCATIONAL_SCORE");
                });
            });

        };
    }
}
