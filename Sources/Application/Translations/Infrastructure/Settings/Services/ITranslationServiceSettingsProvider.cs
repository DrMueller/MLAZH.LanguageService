using Mmu.Mlazh.LanguageService.Translations.Infrastructure.Settings.Models;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.Settings.Services
{
    public interface ITranslationServiceSettingsProvider
    {
        TranslationServiceSettings ProvideSettings();
    }
}