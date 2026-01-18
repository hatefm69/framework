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
        [Description("ستون اول")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون اول را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار ستون اول صحیح نمی باشد")]
        public int Score1 { get; set; }
        [Description("ستون دوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون دوم را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار ستون دوم صحیح نمی باشد")]
        public int Score2 { get; set; }
        [Description("ستون سوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون سوم را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار ستون سوم صحیح نمی باشد")]
        public int Score3 { get; set; }
    }
    public class InColumnWithBoolColumnNotNull : InputsValidator<InColumnWithBoolColumnNotNull>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("ستون اول")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون اول را وارد نمایید")]
        public bool Score1 { get; set; }
        [Description("ستون دوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون دوم را وارد نمایید")]
        public bool Score2 { get; set; }
        [Description("ستون سوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون سوم را وارد نمایید")]
        public bool Score3 { get; set; }
    }
    public class InColumnWithStringColumnNotNull : InputsValidator<InColumnWithStringColumnNotNull>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("ستون اول")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون اول را وارد نمایید")]
        public string Score1 { get; set; }
        [Description("ستون دوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون دوم را وارد نمایید")]
        public string Score2 { get; set; }
        [Description("ستون سوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون سوم را وارد نمایید")]
        public string Score3 { get; set; }
    }







    public class InColumnWithIntColumnNullable : InputsValidator<InColumnWithIntColumnNullable>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("ستون اول")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون اول را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار ستون اول صحیح نمی باشد")]
        public int? Score1 { get; set; }
        [Description("ستون دوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون دوم را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار ستون دوم صحیح نمی باشد")]
        public int? Score2 { get; set; }
        [Description("ستون سوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون سوم را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار ستون سوم صحیح نمی باشد")]
        public int? Score3 { get; set; }
    }
    public class InColumnWithBoolColumnNullable : InputsValidator<InColumnWithBoolColumnNullable>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("ستون اول")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون اول را وارد نمایید")]
        public bool? Score1 { get; set; }
        [Description("ستون دوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون دوم را وارد نمایید")]
        public bool? Score2 { get; set; }
        [Description("ستون سوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون سوم را وارد نمایید")]
        public bool? Score3 { get; set; }
    }
    public class InColumnWithStringColumnNullable : InputsValidator<InColumnWithStringColumnNullable>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("ستون اول")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون اول را وارد نمایید")]
        public string? Score1 { get; set; }
        [Description("ستون دوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون دوم را وارد نمایید")]
        public string? Score2 { get; set; }
        [Description("ستون سوم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ستون سوم را وارد نمایید")]
        public string? Score3 { get; set; }
    }
}
