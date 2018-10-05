using System;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Dtos;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Servants.Implementation
{
    internal class TranslationRestCallFactory : ITranslationRestCallFactory
    {
        private const string ResourcePath = "translate?api-version=3.0";
        private readonly IAuthorizationTokenFactory _authorizationTokenFactory;
        private readonly IRestCallBuilderFactory _restCallBuilderFactory;
        private readonly Uri _translationBaseUrl = new Uri("https://api.cognitive.microsofttranslator.com/");

        public TranslationRestCallFactory(
            IAuthorizationTokenFactory authorizationTokenFactory,
            IRestCallBuilderFactory restCallBuilderFactory)
        {
            _authorizationTokenFactory = authorizationTokenFactory;
            _restCallBuilderFactory = restCallBuilderFactory;
        }

        public async Task<RestCall> CreateAsync(TranslationRequestDto request)
        {
            var resourcePath = CreateResourcePath(request);
            var token = await _authorizationTokenFactory.CreateAuthorizationTokenAsync();

            return _restCallBuilderFactory
                .StartBuilding(_translationBaseUrl, RestCallMethodType.Post)
                .WithouthResourcePath(resourcePath)
                .WithSecurity(RestSecurity.CreateTokenSecurity(token))
                .WithBody(request.Entries)
                .Build();
        }

        private static string CreateResourcePath(TranslationRequestDto request)
        {
            var resourceUrl = ResourcePath;
            var sourceResourceParam = string.Join(string.Empty, request.SourceLanguageCodes.Select(f => "&from=" + f));
            var targetsResourceParam = string.Join(string.Empty, request.TargetLanguageCodes.Select(f => "&to=" + f));

            resourceUrl = string.Concat(resourceUrl, sourceResourceParam, targetsResourceParam);
            return resourceUrl;
        }
    }
}