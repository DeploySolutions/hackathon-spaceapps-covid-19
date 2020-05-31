using System.Threading.Tasks;
using DeploySolutions.Covid19Admin.Configuration.Dto;

namespace DeploySolutions.Covid19Admin.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
