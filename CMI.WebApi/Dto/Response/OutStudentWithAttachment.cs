namespace CMI.WebApi.Dto.Response;

/// <summary>
/// دانش آموز
/// </summary>
public class OutStudentWithAttachment
{
    public OutStudent OutStudent { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
}