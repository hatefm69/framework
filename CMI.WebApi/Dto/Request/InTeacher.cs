namespace CMI.WebApi.Dto.Request;

public class InTeacher : InputsValidator<InTeacher>
{
    // Properties.
    /// <summary>
    /// شناسه
    /// </summary>
    [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه صحیح نمی باشد")]
    public long? Id { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "نام را وارد نمایید")]
    [StringLength(50, ErrorMessage = "تعداد حروف نام نهایتا 50 حرف می باشد")]
    public string FirstName { get; set; }

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "نام خانوادگی را وارد نمایید")]
    [StringLength(50, ErrorMessage = "تعداد حروف نام خانوادگی نهایتا 50 حرف می باشد")]
    public string LastName { get; set; }

    /// <summary>
    /// پایه
    /// </summary>
    [Required(ErrorMessage = "پایه را وارد نمایید")]
    [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار پایه صحیح نمی باشد")]
    public long LevelId { get; set; }

    /// <summary>
    /// شهر
    /// </summary>
    [Required(ErrorMessage = "شهر را وارد نمایید")]
    [Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شهر صحیح نمی باشد")]
    public long CityId { get; set; }

    /// <summary>
    /// وضعیت
    /// </summary>
    [Required(ErrorMessage = "وضعیت را وارد نمایید")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "تاریخ تولد را وارد نمایید")]
    public string BirthDate { get; set; }
    /// <summary>
    /// خیشاوند
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "خیشاوندان را وارد نمایید")]
    public ICollection<InFamilyRelationship> FamilyRelationships { get; set; }


    public override bool IsValid()
    {
        if (!base.IsValid())
            return false;

        if (FamilyRelationships == null || FamilyRelationships.Count <= 0)
        {
            Message = "خیشاوندان را وارد نمایید";
            return false;
        }
        var validFamilyRelations = new List<FamilyRelationshipEnum>()
        {
            FamilyRelationshipEnum.Brother,
            FamilyRelationshipEnum.Sister
        };

        if (this.FamilyRelationships.Where(x => !validFamilyRelations.Contains((FamilyRelationshipEnum)x.FamilyRelationshipId))
            .GroupBy(x => x.FamilyRelationshipId).Where(x => x.Count() > 1).Any())
        {
            Message = "خیشاوندان از نوع خواهر و برادر فقط می تواند بیشتر از 1 نفر باشند!";
            return false;
        }

        if (FamilyRelationships == null || FamilyRelationships.Count <= 0)
        {
            Message = "خیشاوندان را وارد نمایید";
            return false;
        }
        Message = "";
        return true;
    }
}

