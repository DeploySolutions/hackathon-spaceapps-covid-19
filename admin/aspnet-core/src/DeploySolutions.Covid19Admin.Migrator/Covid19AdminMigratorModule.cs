using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DeploySolutions.Covid19Admin.Configuration;
using DeploySolutions.Covid19Admin.EntityFrameworkCore;
using DeploySolutions.Covid19Admin.Migrator.DependencyInjection;

namespace DeploySolutions.Covid19Admin.Migrator
{
    [DependsOn(typeof(Covid19AdminEntityFrameworkModule))]
    public class Covid19AdminMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Covid19AdminMigratorModule(Covid19AdminEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(Covid19AdminMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                Covid19AdminConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Covid19AdminMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
