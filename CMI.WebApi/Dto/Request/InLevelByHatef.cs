namespace CMI.WebApi.Dto.Request
{
    public class InLevelByHatef : InputsValidator<InLevelByHatef>
    {
        // Properties.
        /// <summary>
        /// شناسه
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "عنوان را وارد نمایید")]
        [StringLength(100, ErrorMessage = "تعداد حروف عنوان نهایتا 100 حرف می باشد")]
        public string Title { get; set; }

    }
}