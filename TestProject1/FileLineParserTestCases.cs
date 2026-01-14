namespace TestProject1
{
    public class FileLineParserTestCases : TheoryData<string, string, string>
    {
        public FileLineParserTestCases()
        {
            Add(new DateTime(2025, 10, 01).ToString("yyyy-MM-dd"), "14040709", "2025-10-01");


            Add(new DateTime(2025, 12, 10).ToString("yyyy-MM-dd"), "14040919", "2025-12-10");
            Add(new DateTime(2030, 03, 20).ToString("yyyy-MM-dd"), "14081230", "2030-03-20");
            Add(new DateTime(2030, 03, 21).ToString("yyyy-MM-dd"), "14090101", "2030-03-21");
            Add(new DateTime(2030, 03, 19).ToString("yyyy-MM-dd"), "14081229", "2030-03-19");
        }
    }
}
