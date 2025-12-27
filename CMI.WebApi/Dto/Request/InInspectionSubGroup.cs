namespace CMI.WebApi.Dto.Request
{
    public class InInspectionSubGroup : InputsValidator<InInspectionSubGroup>
    {
        // Properties.
        /// <summary>
        /// شناسه یکتا
        /// </summary>
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه یکتا صحیح نمی باشد")]
        public long? Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "عنوان را وارد نمایید")]
        [StringLength(256, ErrorMessage = "تعداد حروف عنوان نهایتا 256 حرف می باشد")]
        public string Title { get; set; }

        /// <summary>
        /// شناسه گروه بازرسی
        /// </summary>
        [Required(ErrorMessage = "شناسه گروه بازرسی را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه گروه بازرسی صحیح نمی باشد")]
        public long? InspectionGroupId { get; set; }

        /// <summary>
        /// وضعیت فعال/غیرفعال
        /// </summary>
        [Required(ErrorMessage = "وضعیت فعال/غیرفعال را وارد نمایید")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// شرح
        /// </summary>
        [StringLength(256, ErrorMessage = "تعداد حروف شرح نهایتا 256 حرف می باشد")]
        public string Description { get; set; }

    }
}