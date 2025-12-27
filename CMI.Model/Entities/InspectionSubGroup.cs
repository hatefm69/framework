namespace CMI.Model.Entities;

/// <summary>
/// زیرگروه بازرسی
/// </summary>
public class InspectionSubGroup : Entity<long>
{
    // Properties.
    /// <summary>
    /// عنوان
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// شناسه گروه بازرسی
    /// </summary>
    public long InspectionGroupId { get; set; }

    /// <summary>
    /// نام گروه بازرسی
    /// </summary>
    [NotMapped]
    public string InspectionGroupTitle { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// تاریخ غیرفعال سازی
    /// </summary>
    public long? DeactivationDate { get; set; }

    /// <summary>
    /// شرح
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// یک گروه بازرسی
    /// </summary>
    public InspectionGroup InspectionGroup { get; set; }

    [NotMapped]
    public IsUsedInOtherEntities IsUsedInOtherEntities { get; set; }
}