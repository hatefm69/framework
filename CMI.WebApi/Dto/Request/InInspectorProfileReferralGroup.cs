using CMI.Model.Enums;

namespace CMI.WebApi.Dto.Request;
public class InInspectorProfileReferralGroup : InputsValidator<InInspectorProfileReferralGroup>
{
    // Properties.
    /// <summary>
    /// شناسه یکتا
    /// </summary>
    [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه یکتا صحیح نمی باشد")]
    public long? Id { get; set; }

    /// <summary>
    /// شناسه ارجاع گیرنده
    /// </summary>
    [Required(ErrorMessage = "شناسه ارجاع گیرنده را وارد نمایید")]
    [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه ارجاع گیرنده صحیح نمی باشد")]
    public long? InspectorProfileId { get; set; }

    /// <summary>
    /// شناسه گروه ارجاعات
    /// </summary>
    [Required(ErrorMessage = "شناسه گروه ارجاعات را وارد نمایید")]
    [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه گروه ارجاعات صحیح نمی باشد")]
    public ReferralGroupEnum ReferralGroupId { get; set; }

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