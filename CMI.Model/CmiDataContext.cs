using CMI.Model.Mappings;
using FIS.SQL_Oracle;
using System.Diagnostics.CodeAnalysis;


namespace CMI.Model;

public class CmiDataContext : SQL_OracleDataContext
{
    // Constants.
    public const string AppName = "CMI";

    #region Properties.

    public DbSet<InspectionGroup> InspectionGroups { get; set; }

    public DbSet<InspectionSubGroup> InspectionSubGroups { get; set; }

    public DbSet<LevelByHatef> LevelByHatefs { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<FamilyRelationship> FamilyRelationships { get; set; }

    public DbSet<Attachment> Attachments { get; set; }

    // @#$(Auto Code Generator Part)-#001#
    #endregion

    // Events.
    public CmiDataContext()
    {
        ConnetionStringName = AppName;
        ModelCreating = CreateModels;
    }

    public CmiDataContext([NotNull] DbContextOptions options) : base(options)
    {
        ConnetionStringName = AppName;
        ModelCreating = CreateModels;
    }

    // Functions.
    protected void CreateModels(ModelBuilder modelBuilder)
    {
        #region Mappings.

        modelBuilder.ApplyConfiguration(new InspectionGroupMap());
        modelBuilder.ApplyConfiguration(new InspectionSubGroupMap());
        modelBuilder.HasSequence<long>("INSPECTION_TERM_CODE_SEQ").StartsAt(1);
        modelBuilder.ApplyConfiguration(new LevelByHatefMap());
        modelBuilder.ApplyConfiguration(new StudentMap());
        modelBuilder.ApplyConfiguration(new CityMap());
        modelBuilder.ApplyConfiguration(new FamilyRelationshipMap());
        modelBuilder.ApplyConfiguration(new AttachmentMap());
        // @#$(Auto Code Generator Part)-#002#
        #endregion
    }

    public long? Next_SEQ()
    {
        return Database.SqlQuery<long?>($"SELECT INSPECTION_TERM_CODE_SEQ.NEXTVAL FROM dual").AsEnumerable().FirstOrDefault();

    }

}