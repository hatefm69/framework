using FIS.Tools;
using System.ComponentModel.DataAnnotations;

namespace CMI.Model.Models
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
        //    /// <summary>
        //    /// خیشاوند
        //    /// </summary>
        //    [Required(AllowEmptyStrings = false, ErrorMessage = " را وارد نمایید")]
        //    public ICollection<InFamilyRelationshipFromExcel> FamilyRelationships => StrFamilyRelationships.Split("#").Select(x => new InFamilyRelationshipFromExcel
        //    {
        //        familyRelationshipfullName = x.Split(",").First(),
        //        FamilyRelationshipTitle = x.Split(",").Skip(1).First(),
        //    }).ToList();
        //    public override bool IsValid()
        //    {
        //        if (!base.IsValid())
        //            return false;

        //        if (FamilyRelationships == null || FamilyRelationships.Count <= 0)
        //        {
        //            Message = "خیشاوندان را وارد نمایید";
        //            return false;
        //        }
        //        var validFamilyRelations = new List<string>()
        //    {
        //        FamilyRelationshipEnum.Brother.GetDescription(),
        //        FamilyRelationshipEnum.Sister.GetDescription()
        //    };

        //        if (this.FamilyRelationships.Where(x => !validFamilyRelations.Contains(x.FamilyRelationshipTitle))
        //            .GroupBy(x => x.FamilyRelationshipTitle).Where(x => x.Count() > 1).Any())
        //        {
        //            Message = "خیشاوندان از نوع خواهر و برادر فقط می تواند بیشتر از 1 نفر باشند!";
        //            return false;
        //        }

        //        if (FamilyRelationships == null || FamilyRelationships.Count <= 0)
        //        {
        //            Message = "خیشاوندان را وارد نمایید";
        //            return false;
        //        }
        //        Message = "";
        //        return true;
        //    }
    }

    public class InFamilyRelationshipFromExcel : InputsValidator<InFamilyRelationshipFromExcel>
    {
        ///// <summary>
        ///// شناسه دانش آموز
        ///// </summary>
        //[Required(ErrorMessage = "شناسه دانش آموز را وارد نمایید")]
        //[Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه دانش آموز صحیح نمی باشد")]
        //public long? StudentId { get; set; }

        /// <summary>
        /// شناسه نسبت
        /// </summary>
        [Required(ErrorMessage = "شناسه نسبت را وارد نمایید")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "محدوده مقدار شناسه نسبت صحیح نمی باشد")]
        public string FamilyRelationshipTitle { get; set; }

        /// <summary>
        /// نام و نام خانوادگی
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام و نام خانوادگی را وارد نمایید")]
        [StringLength(100, ErrorMessage = "تعداد حروف نام و نام خانوادگی نهایتا 100 حرف می باشد")]
        public string familyRelationshipfullName { get; set; }

    }
    public class InSchoolByExcel : InputsValidator<InSchoolByExcel>
    {

    }
}
