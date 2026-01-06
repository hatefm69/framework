namespace CMI.Model.Mappings
{
    /// <summary>
    /// Attahcment
    /// </summary>
    public class AttachmentMap : EntityMap<Attachment>
    {
        // Events.
        public AttachmentMap()
        {
            MappingConfigurations = (builder) =>
            {
                builder.ToTable("ATTACHMENT");
                builder.Property(pr => pr.Id).HasColumnName("ID").IsRequired();
                builder.Property(pr => pr.FileName).HasColumnName("FILENAME").IsRequired();
                builder.Property(pr => pr.TableId).HasColumnName("TABLE_ID").IsRequired();
                builder.Property(pr => pr.SanaId).HasColumnName("SANA_ID").IsRequired().HasMaxLength(36);
                builder.Property(pr => pr.RecordId).HasColumnName("RECORD_ID").IsRequired();

                // Indexes.
                builder.HasKey(pr => pr.Id);

                // Foreign Keys.

            };
        }
    }
}
