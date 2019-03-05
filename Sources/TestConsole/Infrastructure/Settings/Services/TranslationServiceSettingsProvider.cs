using Mmu.Mlazh.LanguageService.TestConsole.Infrastructure.Settings.Models;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.Settings.Models;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.Settings.Services;
using Mmu.Mlh.SettingsProvisioning.Areas.Factories;

namespace Mmu.Mlazh.LanguageService.TestConsole.Infrastructure.Settings.Services
{
    internal class TranslationServiceSettingsProvider : ITranslationServiceSettingsProvider
    {
        private readonly TestConsoleAppSettings _appSettings;

        public TranslationServiceSettingsProvider(ISettingsFactory settingsFactory)
        {
            _appSettings = settingsFactory.CreateSettings<TestConsoleAppSettings>(
                "AppSettings",
                string.Empty,
                typeof(TranslationServiceSettingsProvider).Assembly.CodeBase);
        }

        public TranslationServiceSettings ProvideSettings()
        {
            return new TranslationServiceSettings(_appSettings.TranslationApiSubscriptionKey);
        }
    }
}