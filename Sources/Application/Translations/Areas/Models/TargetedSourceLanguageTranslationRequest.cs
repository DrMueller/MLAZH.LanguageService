using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.LanguageService.Translations.Areas.Models
{
    public class TargetedSourceLanguageTranslationRequest : TranslationRequest
    {
        public IReadOnlyCollection<string> SourceLanguageCodes { get; }

        public TargetedSourceLanguageTranslationRequest(IReadOnlyCollection<string> sourceLanguageCodes, IReadOnlyCollection<string> targetLanguageCodes, IReadOnlyCollection<string> textParts) : base(targetLanguageCodes, textParts)
        {
            Guard.ObjectNotNull(() => sourceLanguageCodes);
            SourceLanguageCodes = sourceLanguageCodes;
        }
    }
}