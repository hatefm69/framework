namespace CMI.Model.Enums
{
    public class Constant
    {
        public const int MaxLengthDescription = 2048;
        public const string MinYear = "MinYear";
        public const string ExportContentType = "text/csv; charset=UTF-8";
        public const int AfraMaxLengthData = 7;
        public const string AradFormData = "formData";
        public const int FileSize = 2097152;
        public const int FileSizeString = 2;
        public static List<string> ValidExtentions = new List<string> { ".jpg", ".gif", ".png", ".jpeg", ".pdf", ".zip", ".doc", ".docx", ".xls", ".xlsx", ".tif", ".tiff" };
    }
}
