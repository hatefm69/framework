namespace CMI.Model.Mappings;

/// <summary>
/// معلم
/// </summary>
public class TeacherMap : EntityMap<Teacher>
{
    // Events.
    public TeacherMap()
    {
        MappingConfigurations = (builder) =>
        {
            builder.ToTable("TEACHER");
            builder.Property(pr => pr.Id).HasColumnName("ID").ValueGeneratedNever().IsRequired();
            builder.Property(pr => pr.FirstName).HasColumnName("FIRST_NAME").IsRequired().HasMaxLength(50);
            builder.Property(pr => pr.LastName).HasColumnName("LAST_NAME").IsRequired().HasMaxLength(50);
            builder.Property(pr => pr.LevelId).HasColumnName("LEVEL_ID").IsRequired();
            builder.Property(pr => pr.CityId).HasColumnName("CITY_ID").IsRequired();
            builder.Property(pr => pr.IsActive).HasColumnName("IS_ACTIVE").IsRequired();
            builder.Property(pr => pr.BirthDate).HasColumnName("BIRTH_DATE").IsRequired();
            //builder.HasMany(pr => pr.FamilyRelationships).WithOne(pr => pr.Teacher).HasForeignKey(pr => pr.TeacherId).OnDelete(DeleteBehavior.Restrict);

            // Indexes.
            builder.HasKey(pr => pr.Id);

            //Foreign Keys.
            // builder.OwnsMany(builder => builder.EducationalQualification, nc =>
            // {
            //     nc.ToTable("TEACHER_EDUCATIONAL_QUALIFICATION");

            //     // Note: EducationalQualification has StudentId property, but EF Core will handle the foreign key automatically
            //     // The foreign key column will be created automatically by EF Core for the owned entity
            //     nc.WithOwner();

            //     nc.Property<long>("ID");
            //     nc.HasKey("ID");
            //     nc.Property(p => p.Educational)
            //        .HasColumnName("EDUCATIONAL")
            //        .IsRequired()
            //        .HasMaxLength(100);

            //     nc.OwnsOne(nc => nc.Score, score =>
            //     {
            //         score.Property(p => p.Value)
            //        .HasColumnName("EDUCATIONAL_SCORE");
            //     });
            // });

        };
    }
}

