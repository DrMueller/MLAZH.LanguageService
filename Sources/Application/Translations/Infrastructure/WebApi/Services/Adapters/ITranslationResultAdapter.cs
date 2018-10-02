using System.Collections.Generic;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Dtos;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Adapters
{
    internal interface ITranslationResultAdapter
    {
        IReadOnlyCollection<AutoDetectedLanguageTranslationResult> AdaptAutoDetected(IReadOnlyCollection<TranslationResultDto> dtos);

        IReadOnlyCollection<TargetedSourceLanguageTranslationResult> AdaptTargeted(IReadOnlyCollection<TranslationResultDto> dtos);
    }
}