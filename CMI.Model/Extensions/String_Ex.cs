namespace CMI.Model.Extensions
{
    public static class String_Ex
    {
        public static long ToLong(this string value)
        {
            return long.Parse(value);
        }

        public static bool ToBoolean(this string value)
        {
            return bool.Parse(value);
        }

        public static TEnum? ToEnum<TEnum>(this string value)
        where TEnum : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            return Enum.TryParse<TEnum>(value, ignoreCase: true, out var result) ? result : null;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
        public static long ToPersianDate(this string value)
        {
            var dtp = new DateTimeParts()
            {
                DateSeprator = "-"
            };

            dtp.SetDateTime(value, DateTimeType.Gregorian);

            return dtp.GetPersianDate();
        }
    }
}
