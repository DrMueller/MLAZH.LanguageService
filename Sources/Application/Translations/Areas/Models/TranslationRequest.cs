using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.LanguageService.Translations.Areas.Models
{
    public abstract class TranslationRequest
    {
        public IReadOnlyCollection<string> TargetLanguageCodes { get; }
        public IReadOnlyCollection<string> TextParts { get; }

        protected TranslationRequest(IReadOnlyCollection<string> targetLanguageCodes, IReadOnlyCollection<string> textParts)
        {
            Guard.ObjectNotNull(() => textParts);
            Guard.ObjectNotNull(() => targetLanguageCodes);

            if (textParts.Count > 25)
            {
                throw new ArgumentException("The API supports a maximum of 25 text parts.");
            }

            if (textParts.SelectMany(f => f).Count() > 5000)
            {
                throw new ArgumentException("The API supports a maximum of 5000 characters.");
            }

            TextParts = textParts;
            TargetLanguageCodes = targetLanguageCodes;
        }
    }
}