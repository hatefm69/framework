using CMI.Model.Extensions;

namespace CMI.Model.Models
{
    public class BranchManagementTeamAllocationDto
    {
        // Properties.

        /// <summary>
        /// شناسه جدول
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// شناسه جدول گروه ارجاعات
        /// </summary>
        public ReferralGroupEnum ReferralGroupId { get; set; }

        /// <summary>
        /// وضعیت فعال/غیر فعال
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// تاریخ غیر فعال سازی
        /// </summary>
        public long? DeactivationDate { get; set; }

        /// <summary>
        /// کد منطقه
        /// </summary>
        public string RegionCode { get; set; }

        /// <summary>
        /// نام منطقه
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// کد کارشناس
        /// </summary>
        public string PersonelCode { get; set; }

        /// <summary>
        /// نام کارشناس
        /// </summary>
        public string PersonelName { get; set; }


        public string IsActiveTitle => IsActive ? "فعال" : "غیر فعال";

        /// <summary>
        /// تاریخ غیر فعال سازی شمسی
        /// </summary>
        public string DeactivationDateShamsi => DeactivationDate.ToShamsiDate();

        /// <summary>
        /// نام گروه
        /// </summary>
        public string ReferralGroupName => ReferralGroupId.GetDescription();

        //public IsUsedInOtherEntities IsUsedInOtherEntities { get; set; }
    }
}
