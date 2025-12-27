namespace CMI.Model.Extensions;
public static class Enum_Ex
{
    public static string GetDescription(this Enum value)
    {
        return value.GetType().GetMember(value.ToString()).FirstOrDefault()?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? value.ToString();
    }

    public static string ToIntString(this Enum value)
    {
        return Convert.ToInt32(value).ToString();
    }
}