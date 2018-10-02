using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.LanguageService.Translations.Areas.Models
{
    public class DetectedLanguage
    {
        public float AccuracyBetweenOneAndZero { get; }
        public string LanguageCode { get; }

        public DetectedLanguage(string languageCode, float accuracyBetweenOneAndZero)
        {
            Guard.StringNotNullOrEmpty(() => languageCode);

            LanguageCode = languageCode;
            AccuracyBetweenOneAndZero = accuracyBetweenOneAndZero;
        }
    }
}