using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.LanguageService.Translations.Areas.Models
{
    public class Translation
    {
        public string TargetLanguageCode { get; }
        public string Text { get; }

        public Translation(string targetLanguageCode, string text)
        {
            Guard.StringNotNullOrEmpty(() => targetLanguageCode);

            Text = text;
            TargetLanguageCode = targetLanguageCode;
        }
    }
}