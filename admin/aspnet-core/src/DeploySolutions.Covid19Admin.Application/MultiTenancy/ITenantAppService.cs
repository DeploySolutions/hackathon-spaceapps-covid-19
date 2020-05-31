using Abp.Application.Services;
using DeploySolutions.Covid19Admin.MultiTenancy.Dto;

namespace DeploySolutions.Covid19Admin.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

