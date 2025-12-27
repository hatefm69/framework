namespace CMI.WebApi.Dto.Request;
public class InInspectionGroup : InputsValidator<InInspectionGroup>
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
    [Required(AllowEmptyStrings = false, ErrorMessage = "کد را وارد نمایید")]
    [StringLength(50, ErrorMessage = "تعداد حروف کد نهایتا ۵۰ حرف می باشد")]
    public string Code { get; set; }

    /// <summary>
    /// عنوان
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "عنوان را وارد نمایید")]
    [StringLength(256, ErrorMessage = "تعداد حروف عنوان نهایتا ۲۵۶ حرف می باشد")]
    public string Title { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// </summary>
    [Required(ErrorMessage = "وضعیت فعال/غیرفعال را وارد نمایید")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// شرح
    /// </summary>
    [StringLength(256, ErrorMessage = "تعداد حروف شرح نهایتا ۲۵۶ حرف می باشد")]
    public string Description { get; set; }
}