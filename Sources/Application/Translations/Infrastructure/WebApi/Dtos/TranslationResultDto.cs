using System.Collections.Generic;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Dtos
{
    internal class TranslationResultDto
    {
        public DetectedLanguageDto DetectedLanguage { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}