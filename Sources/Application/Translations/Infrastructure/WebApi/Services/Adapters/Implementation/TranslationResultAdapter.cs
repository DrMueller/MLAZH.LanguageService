using System.Collections.Generic;
using System.Linq;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Dtos;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Adapters.Implementation
{
    internal class TranslationResultAdapter : ITranslationResultAdapter
    {
        public IReadOnlyCollection<AutoDetectedLanguageTranslationResult> AdaptAutoDetected(IReadOnlyCollection<TranslationResultDto> dtos)
        {
            return dtos.Select(
                    dto => new AutoDetectedLanguageTranslationResult(
                        AdaptLanguage(dto.DetectedLanguage),
                        AdaptTranslations(dto)))
                .ToList();
        }

        public IReadOnlyCollection<TargetedSourceLanguageTranslationResult> AdaptTargeted(IReadOnlyCollection<TranslationResultDto> dtos)
        {
            return dtos.Select(dto => new TargetedSourceLanguageTranslationResult(AdaptTranslations(dto))).ToList();
        }

        private static DetectedLanguage AdaptLanguage(DetectedLanguageDto dto)
        {
            return new DetectedLanguage(dto.Language, dto.Score);
        }

        private static IReadOnlyCollection<Translation> AdaptTranslations(TranslationResultDto resultDto)
        {
            return resultDto.Translations.Select(f => new Translation(f.To, f.Text)).ToList();
        }
    }
}