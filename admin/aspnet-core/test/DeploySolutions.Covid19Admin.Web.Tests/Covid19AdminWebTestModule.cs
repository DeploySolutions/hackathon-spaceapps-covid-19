using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DeploySolutions.Covid19Admin.EntityFrameworkCore;
using DeploySolutions.Covid19Admin.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace DeploySolutions.Covid19Admin.Web.Tests
{
    [DependsOn(
        typeof(Covid19AdminWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class Covid19AdminWebTestModule : AbpModule
    {
        public Covid19AdminWebTestModule(Covid19AdminEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Covid19AdminWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(Covid19AdminWebMvcModule).Assembly);
        }
    }
}