namespace CMI.WebApi.HelperClasses
{

    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAccessPermissionCheckAttribute : Attribute
    {
        public Type RolesProviderType { get; set; }
    }

    // Create a static class to hold roles
    public static class AdminRoles
    {
        public static readonly string[] PostRoles = { Roles.System_Admin, Roles.Super_Admin, Roles.Supervisor_Admin };
    }
}
