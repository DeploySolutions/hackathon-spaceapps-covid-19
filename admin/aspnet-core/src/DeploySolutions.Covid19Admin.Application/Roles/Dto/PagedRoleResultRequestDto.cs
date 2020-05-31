using Abp.Application.Services.Dto;

namespace DeploySolutions.Covid19Admin.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

