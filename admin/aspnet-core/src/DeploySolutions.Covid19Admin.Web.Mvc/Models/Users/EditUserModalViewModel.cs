using System.Collections.Generic;
using System.Linq;
using DeploySolutions.Covid19Admin.Roles.Dto;
using DeploySolutions.Covid19Admin.Users.Dto;

namespace DeploySolutions.Covid19Admin.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
