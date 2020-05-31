using System.Threading.Tasks;
using Abp.Application.Services;
using DeploySolutions.Covid19Admin.Authorization.Accounts.Dto;

namespace DeploySolutions.Covid19Admin.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
