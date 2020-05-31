using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using DeploySolutions.Covid19Admin.Authorization.Roles;
using DeploySolutions.Covid19Admin.Authorization.Users;
using DeploySolutions.Covid19Admin.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace DeploySolutions.Covid19Admin.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
