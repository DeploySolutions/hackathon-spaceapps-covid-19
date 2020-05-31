using Abp.AutoMapper;
using DeploySolutions.Covid19Admin.Roles.Dto;
using DeploySolutions.Covid19Admin.Web.Models.Common;

namespace DeploySolutions.Covid19Admin.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
