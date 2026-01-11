namespace CMI.Model.Entities
{
    public class StudentWithAttachment
    {
        public Student Student { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
    public class StudentWithFamilyRelation
    {
        public Student Student { get; set; }
        public ICollection<FamilyRelationship> FamilyRelationships { get; set; }
    }
}
