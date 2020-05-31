using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using DeploySolutions.Covid19Admin.Configuration.Dto;

namespace DeploySolutions.Covid19Admin.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : Covid19AdminAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
