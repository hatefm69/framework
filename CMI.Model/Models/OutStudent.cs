using CMI.Model.Extensions;

namespace CMI.Model.Models;

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

    public string LevelTitle { get; set; }
    public string CityTitle { get; set; }
    public string IsActiveStatus => IsActive ? "فعال" : "غیر فعال";
    public bool IsActive { get; set; }
    public long BirthDate { get; set; }
    public string BirthDateGorgianDate => BirthDate.ToGorgianDate();
    public string BirthDatePersianDate => BirthDateGorgianDate.ToPersianWithSpliter();
}