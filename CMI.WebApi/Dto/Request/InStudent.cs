namespace CMI.WebApi.Dto.Request;

public class InStudent : InputsValidator<InStudent>
{
    // Properties.
    /// <summary>
    /// شناسه
    /// </summary>
    [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه صحیح نمی باشد")]
    public long? Id { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "نام را وارد نمایید")]
    [StringLength(50, ErrorMessage = "تعداد حروف نام نهایتا 50 حرف می باشد")]
    public string FirstName { get; set; }

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "نام خانوادگی را وارد نمایید")]
    [StringLength(50, ErrorMessage = "تعداد حروف نام خانوادگی نهایتا 50 حرف می باشد")]
    public string LastName { get; set; }

    /// <summary>
    /// پایه
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "مقدار پایه را وارد نمایید")]
    [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار پایه صحیح نمی باشد")]
    public long LevelId { get; set; }

}