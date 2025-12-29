namespace CMI.Model.Helper;

public static class DateHelper
{
    public const string DateSeparator = "-";

    public static long ToPersion(DateTime date) => new DateTimeParts(date).GetPersianDate();
    public static long ToPersion(string gregorianDate)
    {
        var dtp = new DateTimeParts
        {
            DateSeprator = DateSeparator
        };

        dtp.SetDateTime(gregorianDate, DateTimeType.Gregorian);
        return dtp.GetPersianDate();
    }
    public static string ToGregorian(long persionDate)
    {
        var dtp = new DateTimeParts(persionDate, DateTimeType.Persian)
        {
            DateSeprator = DateSeparator
        };

        return dtp.GetGregorianDateString();
    }
    public static string ToPersionString(long persionDate) => new DateTimeParts(persionDate, DateTimeType.Persian).GetPersianDateString();

    public static string ToPersionYear(DateTime date)
    {
        var dtp = new DateTimeParts(date);
        var persionDate = dtp.GetPersianDate();

        dtp.SetDateTime(persionDate, DateTimeType.Persian);
        return dtp.Year.ToString();
    }


}