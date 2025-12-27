namespace CMI.Model.Enums;

public enum ReferralGroupEnum
{
    /// <summary>
    /// ناظر بر اداره مبارزه با پولشویی
    /// </summary>
    [Description("ناظر بر اداره مبارزه با پولشویی")]
    SupervisorOfTheAntiMoneyLaunderingDepartment = 1,

    /// <summary>
    /// تایید کننده نهایی
    /// </summary>
    [Description("تایید کننده نهایی")]
    FinalApprover = 2,

    /// <summary>
    /// رئیس اداره پولشویی
    /// </summary>
    [Description("رئیس اداره پولشویی")]
    HeadOfTheAntiMoneyLaunderingDepartment = 3,

    /// <summary>
    /// راهبر منطقه
    /// </summary>
    [Description("راهبر منطقه")]
    RegionalLeader = 4,

    /// <summary>
    /// کارشناس پیگیری
    /// </summary>
    [Description("کارشناس پیگیری")]
    TrackingExpert = 5,
}
