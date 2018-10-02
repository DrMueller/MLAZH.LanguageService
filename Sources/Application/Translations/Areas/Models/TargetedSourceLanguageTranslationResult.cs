using System.Collections.Generic;
using System.Text;

namespace Mmu.Mlazh.LanguageService.Translations.Areas.Models
{
    public class TargetedSourceLanguageTranslationResult : TranslationResult
    {
        public TargetedSourceLanguageTranslationResult(IReadOnlyCollection<Translation> translations) : base(translations)
        {
        }

        public override string CreateOverview()
        {
            var sb = new StringBuilder();
            AppendTranslations(sb);

            return sb.ToString();
        }
    }
}