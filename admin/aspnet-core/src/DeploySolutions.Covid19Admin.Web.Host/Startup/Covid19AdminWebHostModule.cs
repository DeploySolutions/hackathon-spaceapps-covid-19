using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DeploySolutions.Covid19Admin.Configuration;

namespace DeploySolutions.Covid19Admin.Web.Host.Startup
{
    [DependsOn(
       typeof(Covid19AdminWebCoreModule))]
    public class Covid19AdminWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public Covid19AdminWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Covid19AdminWebHostModule).GetAssembly());
        }
    }
}
