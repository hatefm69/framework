namespace CMI.Model.Entities;

public class EducationalQualification
{
    public long StudentId { get; set; }
    public string Educational { get; }
    public Score Score { get; }
    //public Student Student { get; set; }
    private EducationalQualification()
    {

    }

    public EducationalQualification(string educational, Score score)
    {
        Educational = educational;
        Score = score;
    }
}
public record Score
{
    public float Value { get; init; }
    public Score(float value)
    {
        Value = value;
    }
}