using System.Collections.Generic;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.LanguageService.Translations.Areas.Models
{
    public class AutoDetectedLanguageTranslationResult : TranslationResult
    {
        public DetectedLanguage DetectedLanguage { get; }

        public AutoDetectedLanguageTranslationResult(DetectedLanguage detectedLanguage, IReadOnlyCollection<Translation> translations) : base(translations)
        {
            Guard.ObjectNotNull(() => detectedLanguage);

            DetectedLanguage = detectedLanguage;
        }

        public override string CreateOverview()
        {
            var sb = new StringBuilder();

            sb.Append("Detected Source: ");
            sb.AppendLine(DetectedLanguage.LanguageCode);
            sb.Append(". Accuracy: ");
            sb.Append(DetectedLanguage.AccuracyBetweenOneAndZero);
            sb.AppendLine(".");
            AppendTranslations(sb);
            return sb.ToString();
        }
    }
}