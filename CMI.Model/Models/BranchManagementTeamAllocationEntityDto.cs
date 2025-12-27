namespace CMI.Model.Models
{
    public class BranchManagementTeamAllocationEntityDto
    {
        /// <summary>
        /// شناسه جدول
        /// </summary>
        public long Id { get; set; }

        // Properties.
        /// <summary>
        /// شناسه جدول گروه ارجاعات
        /// </summary>
        public ReferralGroupEnum ReferralGroupId { get; set; }

        /// <summary>
        /// شناسه جدول بازرس/ارجاع گیرنده 
        /// </summary>
        public long InspectorProfileId { get; set; }

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

        public IsUsedInOtherEntities IsUsedInOtherEntities { get; set; }
    }
}
