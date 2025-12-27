using FIS.Utilities;
using FIS.ZarrirSecurity.Models;
using System.Globalization;

namespace CMI.Model.HelperClasses
{
    public class DatetimeConvert
    {
        public static DateTime? Convert(string persianDateTime)
        {
            if (string.IsNullOrEmpty(persianDateTime))
                return (DateTime?)null;
            return DateTools.ConvertShamsiToMilady(persianDateTime);
        }

        public static string Convert(DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return DateTools.ConvertMiladyToShamsi(dateTime);
            return null;
        }

        public static Tuple<long, long> GetFromAndToDates(long? fromDate, long? toDate)
        {
            var miladiFromDate = EpochConvert.FromUnixTime(fromDate.Value).Date;
            var epochFromDate = EpochConvert.ToUnixTime(miladiFromDate);
            var miladiToDate = EpochConvert.FromUnixTime(toDate.Value).Date.AddDays(1).AddTicks(-1);
            var epochToDate = EpochConvert.ToUnixTime(miladiToDate);

            return Tuple.Create(epochFromDate, epochToDate);

        }

        public static ZimaDropDownItem[] GetYears(int minYear)
        {
            var currentShamsiDate = DatetimeConvert.Convert(DateTime.Now.Date);
            var currentYear = System.Convert.ToInt32(currentShamsiDate.Split('/')[0]);

            var next5Years = currentYear + 5;

            var yearList = new List<ZimaDropDownItem>();
            for (int i = minYear; i <= next5Years; i++)
            {
                var currentYearString = i.ToString();
                yearList.Add(new ZimaDropDownItem
                {
                    Label = currentYearString,
                    Title = currentYearString,
                    Value = currentYearString
                });
            }

            return yearList.ToArray();
        }

        public static Tuple<long, long> GetStartAndEndDateCurrentYear()
        {
            var currentShamsiDate = DatetimeConvert.Convert(DateTime.Now.Date);
            var currentYear = System.Convert.ToInt32(currentShamsiDate.Split('/')[0]);

            PersianCalendar persianCalendar = new PersianCalendar();

            var yearBeginDateTime = persianCalendar.ToDateTime(currentYear, 1, 1, 0, 0, 0, 0);//تاریخ ابتدای سال
            var yearEndDateTime = persianCalendar.ToDateTime((currentYear + 1), 1, 1, 0, 0, 0, 0).AddTicks(-1);//تاریخ انتهای سال
            var yearBeginEpoch = EpochConvert.ToUnixTime(yearBeginDateTime);//تاریخ ابتدای سال
            var yearEndEpoch = EpochConvert.ToUnixTime(yearEndDateTime);//تاریخ انتهای سال

            return Tuple.Create(yearBeginEpoch, yearEndEpoch);
        }
        public static string? FormatePersionData(object? value)
        {
            if (value == null)
                return null;
            if (value.ToString().Contains("/"))
                return value.ToString();
            return value.ToString().Insert(4, "/").Insert(7, "/");
        }
    }
}
