using System.Collections.Generic;
using DeploySolutions.Covid19Admin.Roles.Dto;

namespace DeploySolutions.Covid19Admin.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
