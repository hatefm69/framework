using FIS.Tools;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestProject1
{
    public class InColumnWithIntColumnNotNull : InputsValidator<InColumnWithIntColumnNotNull>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("Column1")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column1 را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار Column1 صحیح نمی باشد")]
        public int Score1 { get; set; }
        [Description("Column2")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column2 را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار Column2 صحیح نمی باشد")]
        public int Score2 { get; set; }
        [Description("Column3")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column3 را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار Column3 صحیح نمی باشد")]
        public int Score3 { get; set; }
    }
    public class InColumnWithBoolColumnNotNull : InputsValidator<InColumnWithBoolColumnNotNull>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("Column1")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column1 را وارد نمایید")]
        public bool Score1 { get; set; }
        [Description("Column2")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column2 را وارد نمایید")]
        public bool Score2 { get; set; }
        [Description("Column3")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column3 را وارد نمایید")]
        public bool Score3 { get; set; }
    }
    public class InColumnWithStringColumnNotNull : InputsValidator<InColumnWithStringColumnNotNull>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("Column1")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column1 را وارد نمایید")]
        public string Score1 { get; set; }
        [Description("Column2")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column2 را وارد نمایید")]
        public string Score2 { get; set; }
        [Description("Column3")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column3 را وارد نمایید")]
        public string Score3 { get; set; }
    }







    public class InColumnWithIntColumnNullable : InputsValidator<InColumnWithIntColumnNullable>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("Column1")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column1 را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار Column1 صحیح نمی باشد")]
        public int? Score1 { get; set; }
        [Description("Column2")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column2 را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار Column2 صحیح نمی باشد")]
        public int? Score2 { get; set; }
        [Description("Column3")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column3 را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار Column3 صحیح نمی باشد")]
        public int? Score3 { get; set; }
    }
    public class InColumnWithBoolColumnNullable : InputsValidator<InColumnWithBoolColumnNullable>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("Column1")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column1 را وارد نمایید")]
        public bool? Score1 { get; set; }
        [Description("Column2")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column2 را وارد نمایید")]
        public bool? Score2 { get; set; }
        [Description("Column3")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column3 را وارد نمایید")]
        public bool? Score3 { get; set; }
    }
    public class InColumnWithStringColumnNullable : InputsValidator<InColumnWithStringColumnNullable>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("Column1")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column1 را وارد نمایید")]
        public string? Score1 { get; set; }
        [Description("Column2")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column2 را وارد نمایید")]
        public string? Score2 { get; set; }
        [Description("Column3")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Column3 را وارد نمایید")]
        public string? Score3 { get; set; }
    }
}
