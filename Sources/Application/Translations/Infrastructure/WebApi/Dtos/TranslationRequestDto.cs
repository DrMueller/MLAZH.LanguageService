using System.Collections.Generic;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Dtos
{
    internal class TranslationRequestDto
    {
        public IReadOnlyCollection<TranslationRequestEntryDto> Entries { get; set; }
        public IReadOnlyCollection<string> SourceLanguageCodes { get; set; }
        public IReadOnlyCollection<string> TargetLanguageCodes { get; set; }
    }
}