namespace CMI.Model.Mappings;

/// <summary>
/// والدین
/// </summary>
public class FamilyRelationshipMap : EntityMap<FamilyRelationship>
{
    // Events.
    public FamilyRelationshipMap()
    {
        MappingConfigurations = (builder) =>
        {
            builder.ToTable("FAMILY_RELATIONSHIP");
            builder.Property(pr => pr.Id).HasColumnName("ID").IsRequired();
            builder.Property(pr => pr.StudentId).HasColumnName("STUDENT_ID").IsRequired();
            builder.Property(pr => pr.FamilyRelationshipId).HasColumnName("FAMILY_RELATIONSHIP_ID").IsRequired();
            builder.Property(pr => pr.FullName).HasColumnName("FULL_NAME").IsRequired().HasMaxLength(100);

            // Indexes.
            builder.HasKey(pr => pr.Id);

            // Foreign Keys.

        };
    }
}
