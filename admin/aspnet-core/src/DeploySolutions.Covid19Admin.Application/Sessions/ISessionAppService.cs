using System.Threading.Tasks;
using Abp.Application.Services;
using DeploySolutions.Covid19Admin.Sessions.Dto;

namespace DeploySolutions.Covid19Admin.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
