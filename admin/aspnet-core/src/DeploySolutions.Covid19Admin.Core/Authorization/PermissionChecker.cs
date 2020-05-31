using Abp.Authorization;
using DeploySolutions.Covid19Admin.Authorization.Roles;
using DeploySolutions.Covid19Admin.Authorization.Users;

namespace DeploySolutions.Covid19Admin.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
