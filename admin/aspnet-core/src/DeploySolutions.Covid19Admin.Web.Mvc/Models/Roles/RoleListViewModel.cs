using System.Collections.Generic;
using DeploySolutions.Covid19Admin.Roles.Dto;

namespace DeploySolutions.Covid19Admin.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
