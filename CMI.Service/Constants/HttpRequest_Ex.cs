namespace CMI.Service.Constants;
public static class HttpRequest_Ex
{
    // Functions.
    public static bool IsAdmin(this HttpRequest httpRequest)
    {
        var userRoles = httpRequest.GetUserRoles();

        if (userRoles == null || userRoles.Count <= 0)
            return false;
        return userRoles.Contains(Roles.Super_Admin) || userRoles.Contains(Roles.System_Admin) || userRoles.Contains(Roles.Supervisor_Admin);
    }
}
