namespace CMI.Model.Models
{
    public class Personnel
    {
        /// <summary>
        /// شناسه پرسنل
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// کد پرسنلی
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// نام پرسنل
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// نام و کد
        /// </summary>
        public string NameCode
        {
            get
            {
                return $"({Code})-{Name}";
            }
        }

        /// <summary>
        /// کد ملی
        /// </summary>
        public string NationalCode { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        //public string BirthDate { get; set; }

        /// <summary>
        /// شماره موبایل
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// اطلاعات پست سازمانی فعلی
        /// </summary>
        //public new Position CurrentPosition { get => base.CurrentPosition != null ? new Position { Code = base.CurrentPosition.Code , Name = base.CurrentPosition.Name } : null; }
        public Position CurrentPosition { get; set; }

        /// <summary>
        /// نام و کد سمت فعلی
        /// </summary>
        public string CurrentPositionNameCode
        {
            get
            {
                if (CurrentPosition != null)
                    return $"({CurrentPosition.Code})-{CurrentPosition.Name}";
                return "";
            }
        }

        /// <summary>
        /// اطلاعات واحد سازمانی فعلی
        /// </summary>
        //public Unit CurrentUnit { get => base.CurrentUnit != null ? new Unit { Code = base.CurrentUnit.Code, Name = base.CurrentUnit.Name } : null; }
        public Unit CurrentUnit { get; set; }

        /// <summary>
        /// نام و کد جایگاه سازمانی فعلی
        /// </summary>
        public string CurrentUnitNameCode
        {
            get
            {
                if (CurrentUnit != null)
                    return $"({CurrentUnit.Code})-{CurrentUnit.Name}";
                return "";
            }
        }
    }
}
