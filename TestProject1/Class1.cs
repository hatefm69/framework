namespace TestProject1
{
    public class FileLineParserTestCases : TheoryData<string, string>
    {
        public FileLineParserTestCases()
        {
            Add(new DateTime(2025, 10, 01).ToString(), "14040709");


            Add(new DateTime(2025, 12, 10).ToString(), "14040919");
            Add(new DateTime(2030, 03, 20).ToString(), "14081230");
            Add(new DateTime(2030, 03, 21).ToString(), "14090101");
            Add(new DateTime(2030, 03, 19).ToString(), "14081229");
        }
    }
}
