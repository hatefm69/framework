using Microsoft.AspNetCore.Http;

namespace CMI.Model.Extensions;

public static class IFormFile_Ex
{
    public static byte[] ToByteArray(this IFormFile formFile)
    {
        using (var ms = new MemoryStream())
        {
            formFile.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
