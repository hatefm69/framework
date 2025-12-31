namespace CMI.WebApi.Dto.Request;

public class InFamilyRelationship : InputsValidator<InFamilyRelationship>
{
    // Properties.
    /// <summary>
    /// شناسه
    /// </summary>
    [Required(ErrorMessage = "شناسه را وارد نمایید")]
    [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه صحیح نمی باشد")]
    public long? Id { get; set; }

    ///// <summary>
    ///// شناسه دانش آموز
    ///// </summary>
    //[Required(ErrorMessage = "شناسه دانش آموز را وارد نمایید")]
    //[Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه دانش آموز صحیح نمی باشد")]
    //public long? StudentId { get; set; }

    /// <summary>
    /// شناسه نسبت
    /// </summary>
    [Required(ErrorMessage = "شناسه نسبت را وارد نمایید")]
    [Range(int.MinValue, int.MaxValue, ErrorMessage = "محدوده مقدار شناسه نسبت صحیح نمی باشد")]
    public int? FamilyRelationshipId { get; set; }

    /// <summary>
    /// نام و نام خانوادگی
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "نام و نام خانوادگی را وارد نمایید")]
    [StringLength(100, ErrorMessage = "تعداد حروف نام و نام خانوادگی نهایتا 100 حرف می باشد")]
    public string familyRelationshipfullName { get; set; }

}