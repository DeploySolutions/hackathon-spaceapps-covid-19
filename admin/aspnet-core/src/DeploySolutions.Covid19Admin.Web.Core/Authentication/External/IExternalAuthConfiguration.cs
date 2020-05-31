using System.Collections.Generic;

namespace DeploySolutions.Covid19Admin.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
