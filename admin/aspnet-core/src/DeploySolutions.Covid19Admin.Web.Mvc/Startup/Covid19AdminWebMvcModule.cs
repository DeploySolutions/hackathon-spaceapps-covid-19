using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DeploySolutions.Covid19Admin.Configuration;
using Abp.AspNetCore.Configuration;

namespace DeploySolutions.Covid19Admin.Web.Startup
{
    [DependsOn(typeof(Covid19AdminWebCoreModule))]
    public class Covid19AdminWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public Covid19AdminWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(Covid19AdminApplicationModule).Assembly, moduleName: "app", useConventionalHttpVerbs: true);
            Configuration.Navigation.Providers.Add<Covid19AdminNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Covid19AdminWebMvcModule).GetAssembly());
        }
    }
}
