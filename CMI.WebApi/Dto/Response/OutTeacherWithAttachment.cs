namespace CMI.WebApi.Dto.Response;

/// <summary>
/// معلم
/// </summary>
public class OutTeacherWithAttachment
{
    public OutTeacher OutTeacher { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
}

