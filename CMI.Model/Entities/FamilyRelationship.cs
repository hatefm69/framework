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
    public long StudentId { get; set; }
    public Student Student { get; set; }

    /// <summary>
    /// شناسه نسبت
    /// </summary>
    public int FamilyRelationshipId { get; set; }

    /// <summary>
    /// نام و نام خانوادگی
    /// </summary>
    public string FullName { get; set; }
}
