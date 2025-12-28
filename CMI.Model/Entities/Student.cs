namespace CMI.Model.Entities;

/// <summary>
/// دانش آموز
/// </summary>
public class Student : Entity<long>
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
    /// پایه
    /// </summary>
    public LevelByHatef Level { get; set; }
    public long CityId { get; set; }
    public City City { get; set; }
}
