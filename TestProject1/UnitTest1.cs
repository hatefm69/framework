using CMI.Model.Extensions;

namespace TestProject1
{
    public class UnitTest1
    {

        [Theory]
        [ClassData(typeof(FileLineParserTestCases))]
        public void Should_Not_Have_Error_When_PersianDate_Is_Equal_With_CycleConvertPersianDate(string date, string finalValue)
        {

            var persianDate = date.ToPersianDate();
            var gorgiandate = persianDate.ToGorgianDate();
            var finalDate = long.Parse(gorgiandate).ToPersianWithSpliter().Replace("/", "");
            var result = string.Equals(finalDate, persianDate);
            Assert.True(result);
        }
        [Theory]
        [ClassData(typeof(FileLineParserTestCases))]
        public void Should_Not_Have_Error_When_PersianDate_Is_Equal_With_CycleConvertPersianDateEqualFinalValue(string date, string finalValue)
        {
            var persianDate = date.ToPersianDate();
            var gorgiandate = persianDate.ToGorgianDate();
            var finalDate = long.Parse(gorgiandate).ToPersianWithSpliter().Replace("/", "");
            var result = string.Equals(finalDate, finalValue);
            Assert.True(result);
        }
    }
}
