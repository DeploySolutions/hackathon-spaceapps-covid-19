using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace DeploySolutions.Covid19Admin.Authorization
{
    public class Covid19AdminAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, Covid19AdminConsts.LocalizationSourceName);
        }
    }
}
