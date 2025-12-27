namespace CMI.Model.HelperClasses
{
    public static class EpochConvert
    {
        public static DateTime FromUnixTime(this long unixTime)
            => DateTimeOffset.FromUnixTimeSeconds(unixTime).LocalDateTime;

        public static long ToUnixTime(this DateTime date)
            => new DateTimeOffset(date).ToUnixTimeSeconds();

        public static long ToUnixTime(string persionDate)
        {
            return ToUnixTime(DatetimeConvert.Convert(persionDate).Value);
        }
    }
}
