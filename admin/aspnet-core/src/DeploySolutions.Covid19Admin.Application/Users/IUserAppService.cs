using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DeploySolutions.Covid19Admin.Roles.Dto;
using DeploySolutions.Covid19Admin.Users.Dto;

namespace DeploySolutions.Covid19Admin.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
