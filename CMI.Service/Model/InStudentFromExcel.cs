using FIS.Tools;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMI.Service.Model
{
    public class InStudentFromExcel : InputsValidator<InStudentFromExcel>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("نام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام را وارد نمایید")]
        [StringLength(50, ErrorMessage = "تعداد حروف نام نهایتا 50 حرف می باشد")]
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>

        [Description("نام خانوادگی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام خانوادگی را وارد نمایید")]
        [StringLength(50, ErrorMessage = "تعداد حروف نام خانوادگی نهایتا 50 حرف می باشد")]
        public string LastName { get; set; }

        /// <summary>
        /// پایه
        /// </summary>

        [Description("پایه")]
        [Required(ErrorMessage = "پایه را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار پایه صحیح نمی باشد")]
        public string LevelTitle { get; set; }

        /// <summary>
        /// شهر
        /// </summary>
        [Description("شهر")]
        [Required(ErrorMessage = "شهر را وارد نمایید")]
        [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شهر صحیح نمی باشد")]
        public string CityTitle { get; set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        [Description("وضعیت")]
        [Required(ErrorMessage = "وضعیت را وارد نمایید")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        [Description("تاریخ تولد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "تاریخ تولد را وارد نمایید")]
        public string BirthDate { get; set; }
        [Description("خویشاوندان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "خیشاوندان را وارد نمایید")]
        public string? StrFamilyRelationships { get; set; }
    }
}
