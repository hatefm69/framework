using CMI.Model.Mappings;
using FIS.SQL_Oracle;
using System.Diagnostics.CodeAnalysis;


namespace CMI.Model
{
    public class CmiDataContext : SQL_OracleDataContext
    {
        // Constants.
        public const string AppName = "CMI";

        #region Properties.

        public DbSet<InspectionGroup> InspectionGroups { get; set; }

        public DbSet<InspectionSubGroup> InspectionSubGroups { get; set; }

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
            // @#$(Auto Code Generator Part)-#002#
            #endregion
        }
    }
}