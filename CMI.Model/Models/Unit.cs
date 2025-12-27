namespace CMI.Model.Models;

public class Unit
{
    public string Code { get; set; }

    public string Name { get; set; }

    public string NameCode
    {
        get
        {
            return $"({Code})-{Name}";
        }
    }

    public string? Type { get; set; }

    public Unit[]? Children { get; set; }
}