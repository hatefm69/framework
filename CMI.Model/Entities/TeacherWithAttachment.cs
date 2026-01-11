namespace CMI.Model.Entities
{
    public class TeacherWithAttachment
    {
        public Teacher Teacher { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
    public class TeacherWithFamilyRelation
    {
        public Teacher Teacher { get; set; }
        public ICollection<FamilyRelationship> FamilyRelationships { get; set; }
    }
}

