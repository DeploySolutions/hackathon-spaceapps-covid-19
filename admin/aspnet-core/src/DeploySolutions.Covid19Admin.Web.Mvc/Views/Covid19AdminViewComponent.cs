using Abp.AspNetCore.Mvc.ViewComponents;

namespace DeploySolutions.Covid19Admin.Web.Views
{
    public abstract class Covid19AdminViewComponent : AbpViewComponent
    {
        protected Covid19AdminViewComponent()
        {
            LocalizationSourceName = Covid19AdminConsts.LocalizationSourceName;
        }
    }
}
