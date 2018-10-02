using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;

namespace Mmu.Mlazh.LanguageService.Translations.Areas.Services
{
    public interface ITranslationService
    {
        Task<IReadOnlyCollection<AutoDetectedLanguageTranslationResult>> AutoTranslateAsync(AutoDetectLanguageTranslationRequest request);

        Task<IReadOnlyCollection<TargetedSourceLanguageTranslationResult>> TranslateAsync(TargetedSourceLanguageTranslationRequest request);
    }
}