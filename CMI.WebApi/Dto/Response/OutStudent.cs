namespace CMI.WebApi.Dto.Response;

/// <summary>
/// دانش آموز
/// </summary>
public class OutStudent
{
    // Properties.
    /// <summary>
    /// شناسه
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// نام کامل
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// پایه
    /// </summary>
    public long LevelId { get; set; }
    public string LevelTitle { get; set; }
    public long CityId { get; set; }
    public string CityTitle { get; set; }
}