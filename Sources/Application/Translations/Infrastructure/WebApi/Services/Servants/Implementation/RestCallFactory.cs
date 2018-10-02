using System;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Dtos;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Servants.Implementation
{
    internal class RestCallFactory : IRestCallFactory
    {
        private const string ResourcePath = "translate?api-version=3.0";
        private readonly IAuthorizationTokenFactory _authorizationTokenFactory;
        private readonly Uri _translationBaseUrl = new Uri("https://api.cognitive.microsofttranslator.com/");

        public RestCallFactory(IAuthorizationTokenFactory authorizationTokenFactory)
        {
            _authorizationTokenFactory = authorizationTokenFactory;
        }

        public async Task<RestCall> CreateAsync(TranslationRequestDto request)
        {
            var resourceUrl = CreateResourceUrl(request);
            var token = await _authorizationTokenFactory.CreateAuthorizationTokenAsync();

            return new RestCall(
                _translationBaseUrl,
                resourceUrl,
                RestCallMethodType.Post,
                SecurityOptions.CreateTokenSecurity(token),
                Maybe.CreateSome<object>(request.Entries));
        }

        private static string CreateResourceUrl(TranslationRequestDto request)
        {
            var resourceUrl = ResourcePath;
            var sourceResourceParam = string.Join(string.Empty, request.SourceLanguageCodes.Select(f => "&from=" + f));
            var targetsResourceParam = string.Join(string.Empty, request.TargetLanguageCodes.Select(f => "&to=" + f));

            resourceUrl = string.Concat(resourceUrl, sourceResourceParam, targetsResourceParam);
            return resourceUrl;
        }
    }
}