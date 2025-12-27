namespace CMI.Model.Mappings
{
    /// <summary>
    /// گروه بازرسی
    /// </summary>
    public class InspectionGroupMap : EntityMap<InspectionGroup>
    {
        // Events.
        public InspectionGroupMap()
        {
            MappingConfigurations = (builder) =>
            {
                builder.ToTable("INSPECTION_GROUP");
                builder.Property(pr => pr.Id).HasColumnName("ID").IsRequired();
                //builder.Property(pr => pr.Code).HasColumnName("CODE").IsRequired().HasMaxLength(50);
                builder.Property(pr => pr.Title).HasColumnName("TITLE").IsRequired().HasMaxLength(256);
                builder.Property(pr => pr.IsActive).HasColumnName("IS_ACTIVE").IsRequired();
                builder.Property(pr => pr.DeactivationDate).HasColumnName("DEACTIVATION_DATE");
                builder.Property(pr => pr.Description).HasColumnName("DESCRIPTION").HasMaxLength(256);

                // Indexes.
                builder.HasKey(pr => pr.Id);

                // Foreign Keys.
                builder.HasMany(pr => pr.InspectionSubGroups).WithOne(pr => pr.InspectionGroup).HasForeignKey(pr => pr.InspectionGroupId).OnDelete(DeleteBehavior.Restrict);
            };
        }
    }
}
