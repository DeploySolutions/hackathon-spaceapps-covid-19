using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DeploySolutions.Covid19Admin.Authorization.Users;

namespace DeploySolutions.Covid19Admin.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
