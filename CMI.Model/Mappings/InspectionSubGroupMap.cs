namespace CMI.Model.Mappings;

/// <summary>
/// زیرگروه بازرسی
/// </summary>
public class InspectionSubGroupMap : EntityMap<InspectionSubGroup>
{
    // Events.
    public InspectionSubGroupMap()
    {
        MappingConfigurations = (builder) =>
        {
            builder.ToTable("INSPECTION_SUB_GROUP");
            builder.Property(pr => pr.Id).HasColumnName("ID").IsRequired();
            builder.Property(pr => pr.Title).HasColumnName("TITLE").IsRequired().HasMaxLength(256);
            builder.Property(pr => pr.InspectionGroupId).HasColumnName("INSPECTION_GROUP_ID").IsRequired();
            builder.Property(pr => pr.IsActive).HasColumnName("IS_ACTIVE").IsRequired();
            builder.Property(pr => pr.DeactivationDate).HasColumnName("DEACTIVATION_DATE");
            builder.Property(pr => pr.Description).HasColumnName("DESCRIPTION").HasMaxLength(256);

            // Indexes.
            builder.HasKey(pr => pr.Id);

            // Foreign Keys.

            // SubGroup
            builder
                .HasOne(sg => sg.InspectionGroup)
                .WithMany(g => g.InspectionSubGroups)
                .HasForeignKey(sg => sg.InspectionGroupId)
                .OnDelete(DeleteBehavior.Restrict);

        };
    }
}

