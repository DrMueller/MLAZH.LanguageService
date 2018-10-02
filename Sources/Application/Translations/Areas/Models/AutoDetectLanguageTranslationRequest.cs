using System.Collections.Generic;

namespace Mmu.Mlazh.LanguageService.Translations.Areas.Models
{
    public class AutoDetectLanguageTranslationRequest : TranslationRequest
    {
        public AutoDetectLanguageTranslationRequest(IReadOnlyCollection<string> targetLanguageCodes, IReadOnlyCollection<string> textParts) : base(targetLanguageCodes, textParts)
        {
        }
    }
}