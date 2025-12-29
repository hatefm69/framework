using FIS.Tools.Exceptions;

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
        public static string ToPersianDate(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            if (DateTime.TryParse(value, out var result))
                return new DateTimeParts().ConvertToPersianDate(result).Replace("/", string.Empty);
            throw new InformationException("Date inputed is not valid!");
        }
        public static string ToGorgianDate(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            var dtp = new DateTimeParts(value.ToLong(), DateTimeType.Persian)
            {
                DateSeprator = ""
            };

            return dtp.GetGregorianDateString();
        }
        public static string ToPersianWithSpliter(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            var date = new DateTimeParts(value.ToLong(), DateTimeType.Gregorian).ToString();
            if (DateTime.TryParse(date, out var result))
                return new DateTimeParts().ConvertToPersianDate(result);

            throw new InformationException("Date inputed is not valid!");

        }
    }
}
