namespace CMI.Model.Entities;
/// <summary>
/// گروه بازرسی
/// </summary>
public class InspectionGroup : Entity<long>
{
    // Properties.
    ///// <summary>
    ///// کد
    ///// </summary>
    //public string Code { get; set; }

    /// <summary>
    /// عنوان
    /// </summary>
    public string Title { get; set; }

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
    /// چند زیر گروه بازرسی
    /// </summary>
    public ICollection<InspectionSubGroup>? InspectionSubGroups { get; set; }

    [NotMapped]
    public IsUsedInOtherEntities IsUsedInOtherEntities { get; set; }
}