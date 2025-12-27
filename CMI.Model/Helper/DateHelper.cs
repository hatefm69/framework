namespace CMI.Model.Helper;
public class DateHelper
{
    public static string GetTodayDateShamsi()
    {
        var dateTimeParts = new DateTimeParts();
        return dateTimeParts.ConvertToPersianDate(DateTime.Now);
    }

    public static long GetTodayDateShamsiWithoutSlash()
    {
        var dateTimeParts = new DateTimeParts();
        return long.Parse(dateTimeParts.ConvertToPersianDate(DateTime.Now).Replace("/", ""));
    }
}