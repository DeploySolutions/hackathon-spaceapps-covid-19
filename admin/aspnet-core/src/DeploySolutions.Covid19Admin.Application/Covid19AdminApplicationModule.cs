using Abp.AspNetCore;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DeploySolutions.Covid19Admin.Authorization;

namespace DeploySolutions.Covid19Admin
{
    [DependsOn(
        typeof(Covid19AdminCoreModule), 
        typeof(AbpAspNetCoreModule),
        typeof(AbpAutoMapperModule))]
    public class Covid19AdminApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<Covid19AdminAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(Covid19AdminApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
