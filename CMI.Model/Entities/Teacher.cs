namespace CMI.Model.Entities;

/// <summary>
/// معلم
/// </summary>
public class Teacher : Entity<long>
{
    // Properties.
    /// <summary>
    /// نام
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// پایه
    /// </summary>
    public long LevelId { get; set; }

    /// <summary>
    /// شهر
    /// </summary>
    public long CityId { get; set; }

    /// <summary>
    /// وضعیت
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// </summary>
    public long BirthDate { get; set; }
    public LevelByHatef Level { get; set; }
    public City City { get; set; }
    //public ICollection<FamilyRelationship> FamilyRelationships { get; set; }

    // public ICollection<EducationalQualification> EducationalQualification { get; set; }
    // public void AddEducationalQualification(string educational, Score score)
    // {
    //     EducationalQualification.Add(new EducationalQualification(educational, score));
    // }

}

