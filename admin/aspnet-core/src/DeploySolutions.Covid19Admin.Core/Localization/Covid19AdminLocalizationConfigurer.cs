using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace DeploySolutions.Covid19Admin.Localization
{
    public static class Covid19AdminLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(Covid19AdminConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(Covid19AdminLocalizationConfigurer).GetAssembly(),
                        "DeploySolutions.Covid19Admin.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
