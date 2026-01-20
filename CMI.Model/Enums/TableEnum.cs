namespace CMI.Model.Enums
{
    public enum TableEnum
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// Student table
        /// </summary>
        Student = 1,
        /// <summary>
        /// Teacher table
        /// </summary>
        Teacher = 2,
    }
    public enum AttachementCategoryEnum
    {
        /// <summary>
        /// Excel type
        /// </summary>
        [Description("مدارک")]
        Excel = 1,
        /// <summary>
        /// Signature type
        /// </summary>
        [Description("امضا")]
        Signature = 2
    }
}
