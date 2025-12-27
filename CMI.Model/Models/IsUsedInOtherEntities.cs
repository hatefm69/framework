namespace CMI.Model.Models;
public class IsUsedInOtherEntities
{
    public bool IsUsed { get; set; }
    public List<string>? EntityNames { get; set; } = new List<string>();
}
