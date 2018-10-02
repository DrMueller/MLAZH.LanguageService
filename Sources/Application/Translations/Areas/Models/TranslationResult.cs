using System.Collections.Generic;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.LanguageService.Translations.Areas.Models
{
    public abstract class TranslationResult
    {
        public IReadOnlyCollection<Translation> Translations { get; }

        protected TranslationResult(IReadOnlyCollection<Translation> translations)
        {
            Guard.ObjectNotNull(() => translations);

            Translations = translations;
        }

        public abstract string CreateOverview();

        protected void AppendTranslations(StringBuilder sb)
        {
            foreach (var trans in Translations)
            {
                sb.Append("Target --> ");
                sb.Append(trans.TargetLanguageCode);
                sb.Append(": ");
                sb.AppendLine(trans.Text);
            }

            sb.AppendLine();
        }
    }
}