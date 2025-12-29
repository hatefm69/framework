namespace CMI.Model.Extensions
{
    public static class Long_Ex
    {
        public static string ToShamsiDate(this long dateTime)
        {
            var dtp = new DateTimeParts();
            return $"{dateTime.ToString().Substring(0, 4)}/{dateTime.ToString().Substring(4, 2)}/{dateTime.ToString().Substring(6, 2)}";
        }

        public static string ToShamsiDate(this long? dateTime)
        {
            if (!dateTime.HasValue)
                return string.Empty;
            var dtp = new DateTimeParts();
            return $"{dateTime.ToString()!.Substring(0, 4)}/{dateTime.ToString()!.Substring(4, 2)}/{dateTime.ToString()!.Substring(6, 2)}";
        }


        public static string ToGorgianDate(this long value)
        {
            var dtp = new DateTimeParts()
            {
                DateSeprator = "-"
            };

            dtp.SetDateTime(value, DateTimeType.Persian);

            return dtp.GetGregorianDateString();
        }

        public static string ToPersianWithSpliter(this long value)
        {
            var dtp = new DateTimeParts()
            {
                DateSeprator = "/"
            };

            dtp.SetDateTime(value, DateTimeType.Persian);

            return dtp.GetDateString();
        }
    }
}
