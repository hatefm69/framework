using ClosedXML.Excel;
using CMI.Service.HelperClasses;
using FIS.Tools.Exceptions;

namespace TestProject1
{
    public class UnitTest_Excel
    {
        [Fact]
        public void Should_Not_Have_Error_When_UploadFileWithIntNotNull_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithIntNotNull.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            var data = workbook.GetData<InColumnWithIntColumnNotNull>();
            Assert.True(data.Count == 3);
            Assert.True(data.First().Score1 == 10);
            Assert.True(data.First().Score2 == 20);
            Assert.True(data.First().Score3 == 30);
            Assert.True(data.Skip(1).First().Score1 == 40);
            Assert.True(data.Skip(1).First().Score2 == 50);
            Assert.True(data.Skip(1).First().Score3 == 60);
            Assert.True(data.Skip(2).First().Score1 == 70);
            Assert.True(data.Skip(2).First().Score2 == 80);
            Assert.True(data.Skip(2).First().Score3 == 90);
        }
        [Fact]
        public void Should_Have_Error_When_UploadFileWithIntNotNull_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithIntNotNullWithEnglishColumn.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            Assert.Throws<InformationException>(() =>
            {
                workbook.GetData<InColumnWithIntColumnNotNull>();
            });

        }
        [Fact]
        public void Should_Have_Error_When_UploadFileWithIntNotNullNotTheSameType_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithIntNotNullNotTheSameType.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            Assert.Throws<InformationException>(() =>
            {
                workbook.GetData<InColumnWithIntColumnNotNull>();
            });

        }
        [Fact]
        public void Should_Not_Have_Error_When_UploadFileWithBoolNotNull_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithBoolNotNull.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            var data = workbook.GetData<InColumnWithBoolColumnNotNull>();
            Assert.True(data.Count == 3);
            Assert.True(data.First().Score1);
            Assert.True(!data.First().Score2);
            Assert.True(!data.First().Score3);
            Assert.True(!data.Skip(1).First().Score1);
            Assert.True(data.Skip(1).First().Score2);
            Assert.True(data.Skip(1).First().Score3);
            Assert.True(data.Skip(2).First().Score1);
            Assert.True(!data.Skip(2).First().Score2);
            Assert.True(data.Skip(2).First().Score3);
        }
        [Fact]
        public void Should_Not_Have_Error_When_UploadFileWithBoolNotNullWithValuesAttribute_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithBoolNotNullWithValuesAttribute.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            var data = workbook.GetData<InColumnWithBoolColumnNotNull>();
            Assert.True(data.Count == 3);
            Assert.True(data.First().Score1);
            Assert.True(!data.First().Score2);
            Assert.True(!data.First().Score3);
            Assert.True(!data.Skip(1).First().Score1);
            Assert.True(data.Skip(1).First().Score2);
            Assert.True(data.Skip(1).First().Score3);
            Assert.True(data.Skip(2).First().Score1);
            Assert.True(!data.Skip(2).First().Score2);
            Assert.True(data.Skip(2).First().Score3);
        }
        [Fact]
        public void Should_Have_Error_When_UploadFileWithBoolNotNullNotTheSameType_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithBoolNotNullNotTheSameType.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            Assert.Throws<InformationException>(() =>
            {
                workbook.GetData<InColumnWithIntColumnNotNull>();
            });
        }
        [Fact]
        public void Should_Have_Error_When_UploadFileWithBoolNotNull_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithBoolNotNullWithEnglishColumn.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            Assert.Throws<InformationException>(() =>
            {
                workbook.GetData<InColumnWithIntColumnNotNull>();
            });
        }
        [Fact]
        public void Should_Not_Have_Error_When_UploadFileWithStringNotNull_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithStringNotNull.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            var data = workbook.GetData<InColumnWithStringColumnNotNull>();
            Assert.True(data.Count == 3);
            Assert.True(data.First().Score1 == "Score1");
            Assert.True(data.First().Score2 == "Score2");
            Assert.True(data.First().Score3 == "Score3");
            Assert.True(data.Skip(1).First().Score1 == "Score4");
            Assert.True(data.Skip(1).First().Score2 == "Score5");
            Assert.True(data.Skip(1).First().Score3 == "Score6");
            Assert.True(data.Skip(2).First().Score1 == "Score7");
            Assert.True(data.Skip(2).First().Score2 == "Score8");
            Assert.True(data.Skip(2).First().Score3 == "Score9");
        }
        [Fact]
        public void Should_Have_Error_When_UploadFileWithStringNotNull_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithStringNotNullWithEnglishColumn.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            Assert.Throws<InformationException>(() =>
            {
                workbook.GetData<InColumnWithIntColumnNotNull>();
            });
        }

        [Fact]
        public void Should_Not_Have_Error_When_UploadFileWithIntNullable_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithIntNullable.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            var data = workbook.GetData<InColumnWithIntColumnNullable>();
            Assert.True(data.Count == 3);
            Assert.True(data.First().Score1 == null);
            Assert.True(data.First().Score2 == 20);
            Assert.True(data.First().Score3 == 30);
            Assert.True(data.Skip(1).First().Score1 == 40);
            Assert.True(data.Skip(1).First().Score2 == 50);
            Assert.True(data.Skip(1).First().Score3 == null);
            Assert.True(data.Skip(2).First().Score1 == 70);
            Assert.True(data.Skip(2).First().Score2 == null);
            Assert.True(data.Skip(2).First().Score3 == 90);
        }
        [Fact]
        public void Should_Not_Have_Error_When_UploadFileWithIntNullableNotTheSameType_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithIntNullableNotTheSameType.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            Assert.Throws<InformationException>(() =>
            {
                workbook.GetData<InColumnWithIntColumnNotNull>();
            });
        }
        [Fact]
        public void Should_Have_Error_When_UploadFileWithIntNullable_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithIntNullableWithEnglishColumn.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            Assert.Throws<InformationException>(() =>
            {
                workbook.GetData<InColumnWithIntColumnNotNull>();
            });
        }
        [Fact]
        public void Should_Not_Have_Error_When_UploadFileWithBoolNullable_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithBoolNullable.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            var data = workbook.GetData<InColumnWithBoolColumnNullable>();
            Assert.True(data.Count == 3);
            Assert.True(data.First().Score1 == null);
            Assert.True(!data.First().Score2);
            Assert.True(!data.First().Score3);
            Assert.True(!data.Skip(1).First().Score1);
            Assert.True(data.Skip(1).First().Score2);
            Assert.True(data.Skip(1).First().Score3 == null);
            Assert.True(data.Skip(2).First().Score1 == null);
            Assert.True(!data.Skip(2).First().Score2);
            Assert.True(data.Skip(2).First().Score3);
        }
        [Fact]
        public void Should_Have_Error_When_UploadFileWithBoolNullableNotTheSameType_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithBoolNullableNotTheSameType.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            Assert.Throws<InformationException>(() =>
            {
                workbook.GetData<InColumnWithIntColumnNotNull>();
            });
        }
        [Fact]
        public void Should_Have_Error_When_UploadFileWithBoolNullable_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithBoolNullableWithEnglishColumn.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            Assert.Throws<InformationException>(() =>
            {
                workbook.GetData<InColumnWithIntColumnNotNull>();
            });
        }
        [Fact]
        public void Should_Not_Have_Error_When_UploadFileWithStringNullable_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithStringNullable.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            var data = workbook.GetData<InColumnWithStringColumnNullable>();
            Assert.True(data.Count == 3);
            Assert.True(data.First().Score1 == "Score1");
            Assert.True(data.First().Score2 == "Score2");
            Assert.True(data.First().Score3 == null);
            Assert.True(data.Skip(1).First().Score1 == null);
            Assert.True(data.Skip(1).First().Score2 == "Score5");
            Assert.True(data.Skip(1).First().Score3 == "Score6");
            Assert.True(data.Skip(2).First().Score1 == "Score7");
            Assert.True(data.Skip(2).First().Score2 == null);
            Assert.True(data.Skip(2).First().Score3 == "Score9");
        }
        [Fact]
        public void Should_Have_Error_When_UploadFileWithStringNullable_Is_Equal_With_finalValue()
        {
            var fileName = "ColumnWithStringNullableWithEnglishColumn.xlsx";
            var filePath = Path.Combine("D:\\Projects\\CMI\\BackEnd\\TestProject1", fileName);
            var stream = File.Open(filePath, FileMode.Open);
            using var workbook = new XLWorkbook(stream);
            Assert.Throws<InformationException>(() =>
            {
                workbook.GetData<InColumnWithIntColumnNotNull>();
            });
        }

    }
}
