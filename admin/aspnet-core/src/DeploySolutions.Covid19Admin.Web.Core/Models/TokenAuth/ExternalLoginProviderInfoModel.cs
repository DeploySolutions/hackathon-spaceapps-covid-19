using Abp.AutoMapper;
using DeploySolutions.Covid19Admin.Authentication.External;

namespace DeploySolutions.Covid19Admin.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
