using System.Collections.Generic;
using DeploySolutions.Covid19Admin.Roles.Dto;

namespace DeploySolutions.Covid19Admin.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}