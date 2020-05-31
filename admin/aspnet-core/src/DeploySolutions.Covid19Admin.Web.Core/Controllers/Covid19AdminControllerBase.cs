using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace DeploySolutions.Covid19Admin.Controllers
{
    public abstract class Covid19AdminControllerBase: AbpController
    {
        protected Covid19AdminControllerBase()
        {
            LocalizationSourceName = Covid19AdminConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
