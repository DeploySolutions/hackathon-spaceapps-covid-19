using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace DeploySolutions.Covid19Admin.Web.Views
{
    public abstract class Covid19AdminRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected Covid19AdminRazorPage()
        {
            LocalizationSourceName = Covid19AdminConsts.LocalizationSourceName;
        }
    }
}
