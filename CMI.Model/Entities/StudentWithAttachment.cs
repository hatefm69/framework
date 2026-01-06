namespace CMI.Model.Entities
{
    public class StudentWithAttachment
    {
        public Student Student { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}
