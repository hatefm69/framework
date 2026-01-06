using CMI.Service.Classes;
using FIS.DataStorageFramework.Extentions;
using FIS.Utilities.ExcelFileGenerator;
using FIS.WebAPIFramework.Extentions;
using Microsoft.EntityFrameworkCore;

namespace CMI.WebApi.Classes;

/// <summary>
/// Cofigure services
/// </summary>
public static class ServicesConfig
{
    // Private Functions.
    private static void ConfigFramework(IServiceCollection services)
    {
        services.InjectDataContextAndServiceLocator<CmiDataContext>(connetionStringName: CmiDataContext.AppName, oracleSQLCompatibility: OracleSQLCompatibility.DatabaseVersion19);
        services.DisableAutomaticModelValidation();
        services.RegisterErrorHandler<ExceptionHandler>();
        //services.RegisterUserLogHandler<UserLogHandler>();
        //services.RegisterAuthenticationPermissionHandler<AuthenPermissionHandler>();
        //services.RegisterLogHandler<Logging>();
        //services.RegisterInputModelRevisorHandler<ModelRevisor>();
    }

    private static void ConfigServices(IServiceCollection services)
    {
        services.Add(new ServiceDescriptor(typeof(IInspectionGroupService), typeof(InspectionGroupService), ServiceLifetime.Scoped));
        services.Add(new ServiceDescriptor(typeof(IInspectionSubGroupService), typeof(InspectionSubGroupService), ServiceLifetime.Scoped));
        services.Add(new ServiceDescriptor(typeof(ILevelByHatefService), typeof(LevelByHatefService), ServiceLifetime.Scoped));
        services.Add(new ServiceDescriptor(typeof(IStudentService), typeof(StudentService), ServiceLifetime.Scoped));
        services.Add(new ServiceDescriptor(typeof(ICityService), typeof(CityService), ServiceLifetime.Scoped));
        services.Add(new ServiceDescriptor(typeof(IFamilyRelationshipService), typeof(FamilyRelationshipService), ServiceLifetime.Scoped));
        			services.Add(new ServiceDescriptor(typeof(IAttachmentService), typeof(AttachmentService), ServiceLifetime.Scoped));
// @#$(Auto Code Generator Part)-#001#
    }

    private static void ConfigTools(IServiceCollection services)
    {
        services.Add(new ServiceDescriptor(typeof(IExcelFileManagerService), typeof(ExcelFileManagerService), ServiceLifetime.Scoped));
        //services.Add(new ServiceDescriptor(typeof(IExcelFileManagerService), typeof(ExcelFileManagerService), ServiceLifetime.Scoped));
    }

    // Public Functions.
    /// <summary>
    /// Configure data context and services.
    /// </summary>
    /// <param name="services"></param>
    public static void Configure(this IServiceCollection services)
    {
        ConfigFramework(services);
        ConfigServices(services);
        ConfigTools(services);
    }
}
