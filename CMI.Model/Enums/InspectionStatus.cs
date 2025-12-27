namespace CMI.Model.Enums
{

    public enum InspectionStatus
    {
        Active = 22,

        /// <summary>
        /// بازخرید
        /// </summary>
        BuyBack = 23,

        /// <summary>
        /// بازنشسته
        /// </summary>
        Retired = 24,

        /// <summary>
        /// ماموریت
        /// </summary>
        Agent = 25,

        /// <summary>
        /// در اختیار مشتری
        /// </summary>
        AvailableCustomer = 26,

        /// <summary>
        /// مرخصی
        /// </summary>
        Leave = 27,
        /// <summary>
        /// مرخصی با حقوق
        /// </summary>
        LeavePaid = 110,
        /// <summary>
        /// مرخصی استعلاجی
        /// </summary>
        LeaveIllness = 111,
    }
}
