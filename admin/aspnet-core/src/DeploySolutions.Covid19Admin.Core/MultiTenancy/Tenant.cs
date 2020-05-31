using Abp.MultiTenancy;
using DeploySolutions.Covid19Admin.Authorization.Users;

namespace DeploySolutions.Covid19Admin.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
