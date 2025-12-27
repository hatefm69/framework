namespace CMI.Model.Enums
{
    public class ErrorMessage
    {
        public const string NotFoundEnvironmentVariable = "متغیر سیستمی یافت نشد";
        public const string JustEditIsActiveStatus = "به دلیل داده وابسته ، فقط امکان ویرایش وضعیت وجود دارد";
        public const string NotFoundData = "داده ای با شناسه ارسالی یافت نشد";
        public const string DeleteDependentData = "به دلیل داده وابسته قابل حذف نمی باشد";
        public const string DuplicateData = "رکورد تکراری می باشد";
        public const string InValidInputModel = "مدل ورودی نامعتبر می باشد";
        public const string NotSelectFile = "لطفا فایل را انتخاب نمایید";
        public const string NotFoundAttachment = "فایل مورد نظر پیدا نشد";
        public const string DuplicateInspector = "بازرس تکراری می باشد";
        public const string NotFoundInspector = "بازرس یافت نشد";
        public const string ErrorUploadFile = "خطا در بارگزاری فایل";
    }
}
