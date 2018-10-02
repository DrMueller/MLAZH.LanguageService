using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services
{
    internal interface ITranslationApiProxy
    {
        Task<IReadOnlyCollection<AutoDetectedLanguageTranslationResult>> AutoTranslateAsync(AutoDetectLanguageTranslationRequest request);

        Task<IReadOnlyCollection<TargetedSourceLanguageTranslationResult>> TranslateAsync(TargetedSourceLanguageTranslationRequest request);
    }
}