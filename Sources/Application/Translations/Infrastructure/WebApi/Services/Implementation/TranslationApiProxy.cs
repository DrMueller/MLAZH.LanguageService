using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Dtos;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Adapters;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Servants;
using Mmu.Mlh.RestExtensions.Areas.RestProxies;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Implementation
{
    internal class TranslationApiProxy : ITranslationApiProxy
    {
        private readonly IMapper _mapper;
        private readonly ITranslationRestCallFactory _restCallFactory;
        private readonly IRestProxy _restProxy;
        private readonly ITranslationResultAdapter _translationResultAdapter;

        public TranslationApiProxy(
            IRestProxy restProxy,
            ITranslationRestCallFactory restCallFactory,
            IMapper mapper,
            ITranslationResultAdapter translationResultAdapter)
        {
            _restProxy = restProxy;
            _restCallFactory = restCallFactory;
            _mapper = mapper;
            _translationResultAdapter = translationResultAdapter;
        }

        public async Task<IReadOnlyCollection<AutoDetectedLanguageTranslationResult>> AutoTranslateAsync(AutoDetectLanguageTranslationRequest request)
        {
            var translationResultDtos = await FetchTranslationsAsync(request);
            var result = _translationResultAdapter.AdaptAutoDetected(translationResultDtos);
            return result;
        }

        public async Task<IReadOnlyCollection<TargetedSourceLanguageTranslationResult>> TranslateAsync(TargetedSourceLanguageTranslationRequest request)
        {
            var translationResultDtos = await FetchTranslationsAsync(request);
            var result = _translationResultAdapter.AdaptTargeted(translationResultDtos);
            return result;
        }

        private async Task<List<TranslationResultDto>> FetchTranslationsAsync(TranslationRequest request)
        {
            var requestDto = _mapper.Map<TranslationRequestDto>(request);
            var restCall = await _restCallFactory.CreateAsync(requestDto);
            var translationResultDtos = await _restProxy.PerformCallAsync<List<TranslationResultDto>>(restCall);

            return translationResultDtos;
        }
    }
}