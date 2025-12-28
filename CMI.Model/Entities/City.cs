namespace CMI.Model.Entities;

/// <summary>
/// شهر
/// </summary>
public class City : Entity<long>
{
    // Properties.
    /// <summary>
    /// عنوان
    /// </summary>
    public string Title { get; set; }
    public ICollection<Student> Students { get; set; }

}
