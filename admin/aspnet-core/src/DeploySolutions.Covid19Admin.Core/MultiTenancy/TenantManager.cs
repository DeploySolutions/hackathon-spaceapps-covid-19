using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using DeploySolutions.Covid19Admin.Authorization.Users;
using DeploySolutions.Covid19Admin.Editions;

namespace DeploySolutions.Covid19Admin.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
