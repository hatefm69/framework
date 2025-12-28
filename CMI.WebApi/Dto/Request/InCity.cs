namespace CMI.WebApi.Dto.Request
{
    public class InCity : InputsValidator<InCity>
    {
        // Properties.
        /// <summary>
        /// شناسه
        /// </summary>
        [Required(ErrorMessage = "شناسه را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه صحیح نمی باشد")]
        public long? Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "عنوان را وارد نمایید")]
        [StringLength(50, ErrorMessage = "تعداد حروف عنوان نهایتا 50 حرف می باشد")]
        public string Title { get; set; }

    }
}