using CMI.Model.Extensions;

namespace TestProject1
{
    public class UnitTest
    {

        [Theory]
        [ClassData(typeof(FileLineParserTestCases))]
        public void Should_Not_Have_Error_When_GorgianToPersian_Is_Equal_With_finalValue(string date, string finalValue, string finalGorgiandate)
        {
            var persianDate = date.ToPersianDate(DateSepratorEnum.Dash);
            var result = string.Equals(finalValue.ToString(), persianDate.ToString());
            Assert.True(result);
        }
        [Theory]
        [ClassData(typeof(FileLineParserTestCases))]
        public void Should_Not_Have_Error_When_GorgianToPersian_Is_Equal_With_CycleConvertGorgianEqualFinalGorgiandate(string date, string finalValue, string finalGorgiandate)
        {
            var persianDate = date.ToPersianDate(DateSepratorEnum.Dash);
            var gorgiandate = persianDate.ToGorgianDate();

            var result = string.Equals(finalGorgiandate.ToString(), gorgiandate.ToString());
            Assert.True(result);
        }
    }
}
