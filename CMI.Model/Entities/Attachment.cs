namespace CMI.Model.Entities
{
    /// <summary>
    /// Attahcment
    /// </summary>
    public class Attachment : Entity<long>
    {
        // Properties.
        /// <summary>
        /// عنوان
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// شناسه جدول
        /// </summary>
        public TableEnum TableId { get; set; }

        /// <summary>
        /// شناسه سانا
        /// </summary>
        public string SanaId { get; set; }

        /// <summary>
        /// شناسه رکورد
        /// </summary>
        public long RecordId { get; set; }
        public AttachementCategoryEnum AttachmentCategoryId { get; set; }

    }

}
