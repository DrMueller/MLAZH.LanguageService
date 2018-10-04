using Mmu.Mlazh.LanguageService.TestConsole.Infrastructure.Settings.Models;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.Settings.Models;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.Settings.Services;

namespace Mmu.Mlazh.LanguageService.TestConsole.Infrastructure.Settings.Services
{
    internal class TranslationServiceSettingsProvider : ITranslationServiceSettingsProvider
    {
        private readonly TestConsoleAppSettings _appSettings;

        public TranslationServiceSettingsProvider(TestConsoleAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public TranslationServiceSettings ProvideSettings()
        {
            return new TranslationServiceSettings(_appSettings.TranslationApiSubscriptionKey);
        }
    }
}