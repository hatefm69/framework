namespace CMI.Model.Entities;

/// <summary>
/// والدین
/// </summary>
public class FamilyRelationship : Entity<long>
{
    // Properties.
    /// <summary>
    /// شناسه دانش آموز
    /// </summary>
    public long RecordId { get; set; }
    public TableEnum TableId { get; set; }
    // public Student Student { get; set; }
    // public long TeacherId { get; set; }
    // public Teacher Teacher { get; set; }
    /// <summary>
    /// شناسه نسبت
    /// </summary>
    public int FamilyRelationshipId { get; set; }

    /// <summary>
    /// نام و نام خانوادگی
    /// </summary>
    public string FullName { get; set; }
}
