using FIS.Sana;
using FIS.Sana.Models;

namespace CMI.Service.HelperClasses
{
    public class SanaHelper
    {
        #region Public

        public static List<SanaFileInfo> UploadFiles(IFormFileCollection files)
        {
            var sanaFileInfos = new List<SanaFileInfo>();
            var fileInformationList = new List<FileInformation>();
            foreach (var file in files)
            {
                ValidateFile(file);

                fileInformationList.Add(new FileInformation
                {
                    FileName = file.FileName,
                    FolderName = sanaFolderName,
                    Title = "",
                    FileData = ConvertToByteArray(file)
                });
            }
            var fileList = files.ToList();
            var result = SanaInstance.UploadFiles(fileInformationList);
            if (result == null ||
                result.Data == null ||
                !result.IsSuccessed)
                throw new InformationException(ErrorMessage.ErrorUploadFile);

            foreach (var item in result.Data)
            {
                sanaFileInfos.Add(new SanaFileInfo
                {
                    Id = item.Id,
                    FileSize = item.Size,
                    Filename = item.Name,
                });
            }
            return sanaFileInfos;
            //var signature = attachmentList.Where(attachment => attachment.ControlName.ToLower() == SignaturePhoto).FirstOrDefault();


            //if (signature != null)
            //{
            //    if (entities != null && entities.SignatureAttahcment != null)
            //        inputData.RemoveFileIdList.Add(entities.SignatureAttahcment.Id);

            //    inputData.Signature = signature.Id;
            //}

            //if (inputData.RemoveFileIdList.Any())
            //    GetService<Attachment, AttachmentRepository, AttachmentService>().RemoveFileList(inputData.RemoveFileIdList);
        }

        #endregion

        #region Private

        private static ISana SanaInstance { get { return ExternalServices.GetSana(); } }

        private static readonly string sanaFolderName = "cmi";

        private static byte[]? ConvertToByteArray(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return fileBytes;
            }
        }
        private static void ValidateFile(IFormFile file)
        {
            if (file.Length > Constant.FileSize)
                throw new InformationException($"حجم فایل با نام {file.FileName} نمیتواند بیشتر از ${Constant.FileSizeString} مگابایت باشد");

            var extention = Path.GetExtension(file.FileName);
            if (!Constant.ValidExtentions.Any(validExtension => validExtension == extention.ToLower()))
                throw new InformationException($"پسوند فایل با نام {file.FileName} نامعتبر می باشد");
        }

        #endregion
    }

}
