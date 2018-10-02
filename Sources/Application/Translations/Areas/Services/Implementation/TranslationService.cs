using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services;

namespace Mmu.Mlazh.LanguageService.Translations.Areas.Services.Implementation
{
    internal class TranslationService : ITranslationService
    {
        private readonly ITranslationApiProxy _apiProxy;

        public TranslationService(ITranslationApiProxy apiProxy)
        {
            _apiProxy = apiProxy;
        }

        public async Task<IReadOnlyCollection<AutoDetectedLanguageTranslationResult>> AutoTranslateAsync(AutoDetectLanguageTranslationRequest request)
        {
            return await _apiProxy.AutoTranslateAsync(request);
        }

        public async Task<IReadOnlyCollection<TargetedSourceLanguageTranslationResult>> TranslateAsync(TargetedSourceLanguageTranslationRequest request)
        {
            return await _apiProxy.TranslateAsync(request);
        }
    }
}