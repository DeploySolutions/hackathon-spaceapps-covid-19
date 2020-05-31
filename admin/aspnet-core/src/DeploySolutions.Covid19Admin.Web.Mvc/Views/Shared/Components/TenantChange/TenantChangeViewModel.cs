using Abp.AutoMapper;
using DeploySolutions.Covid19Admin.Sessions.Dto;

namespace DeploySolutions.Covid19Admin.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
