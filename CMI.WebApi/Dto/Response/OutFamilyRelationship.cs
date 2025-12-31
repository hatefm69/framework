namespace CMI.WebApi.Dto.Response;

/// <summary>
/// والدین
/// </summary>
public class OutFamilyRelationship
{
    // Properties.
    /// <summary>
    /// شناسه
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه دانش آموز
    /// </summary>
    public long StudentId { get; set; }

    /// <summary>
    /// شناسه نسبت
    /// </summary>
    public int FamilyRelationshipId { get; set; }

    /// <summary>
    /// نام و نام خانوادگی
    /// </summary>
    public string FullName { get; set; }
    public string familyRelationshipfullName => FullName;
    public string familyRelationshipTitle => ((FamilyRelationshipEnum)FamilyRelationshipId).GetDescription();

}