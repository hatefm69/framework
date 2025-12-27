using CMI.Model.Extensions;

namespace CMI.WebApi.Dto.Response;

/// <summary>
/// زیرگروه بازرسی
/// </summary>
public class OutInspectionSubGroup
{
    // Properties.
    /// <summary>
    /// شناسه یکتا
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// عنوان
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// شناسه گروه بازرسی
    /// </summary>
    public long InspectionGroupId { get; set; }

    /// <summary>
    /// زیر گروه بازرسی
    /// </summary>
    public string InspectionGroupTitle { get; set; }

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
}