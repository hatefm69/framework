namespace CMI.Model.Mappings
{
    /// <summary>
    /// سطوح
    /// </summary>
    public class LevelByHatefMap : EntityMap<LevelByHatef>
    {
        // Events.
        public LevelByHatefMap()
        {
            MappingConfigurations = (builder) =>
            {
                builder.ToTable("LEVEL_BY_HATEF");
                builder.Property(pr => pr.Id).HasColumnName("ID").IsRequired();
                builder.Property(pr => pr.Title).HasColumnName("TITLE").IsRequired().HasMaxLength(100);

                // Indexes.
                builder.HasKey(pr => pr.Id);

                // Foreign Keys.

            };
        }
    }
}
