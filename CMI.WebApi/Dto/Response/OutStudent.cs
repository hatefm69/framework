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
    /// پایه
    /// </summary>
    public long LevelId { get; set; }
    public string LevelTitle { get; set; }
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
    public string BirthDate { get; set; }
    public string FullName { get; set; }
    public ZimaTableColumn[][]? familyRelationshipsTableData { get; set; }
}