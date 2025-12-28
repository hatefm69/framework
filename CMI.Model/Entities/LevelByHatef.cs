namespace CMI.Model.Entities;

/// <summary>
/// سطوح
/// </summary>
public class LevelByHatef : Entity<long>
{
    // Properties.
    /// <summary>
    /// عنوان
    /// </summary>
    public string Title { get; set; }
    public ICollection<Student>? Students { get; set; }

}
