using CMI.Model.Extensions;

namespace CMI.WebApi.Dto.Response;
/// <summary>
/// گروه بازرسی
/// </summary>
public class OutInspectionGroup
{
    // Properties.
    /// <summary>
    /// شناسه یکتا
    /// </summary>
    public long Id { get; set; }

    ///// <summary>
    ///// کد گروه
    ///// </summary>
    //public long Code { get; set; }

    /// <summary>
    /// عنوان
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    ///  عنوان وضعیت فعال/غیرفعال
    /// </summary>
    public string IsActiveTitle => IsActive ? "فعال" : "غیرفعال";

    /// <summary>
    /// تاریخ غیرفعال سازی
    /// </summary>
    public long? DeactivationDate { get; set; }

    /// <summary>
    /// تاریخ شمسی غیرفعال سازی
    /// </summary>
    public string? DeactivationDateShamsi => DeactivationDate.ToShamsiDate();

    /// <summary>
    /// شرح
    /// </summary>
    public string Description { get; set; }

    public IsUsedInOtherEntities IsUsedInOtherEntities { get; set; }
}