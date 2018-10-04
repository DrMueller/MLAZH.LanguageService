using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.Settings.Models
{
    public class TranslationServiceSettings
    {
        public string TranslateApiSubscriptionKey { get; }

        public TranslationServiceSettings(string translateApiSubscriptionKey)
        {
            Guard.StringNotNullOrEmpty(() => translateApiSubscriptionKey);

            TranslateApiSubscriptionKey = translateApiSubscriptionKey;
        }
    }
}