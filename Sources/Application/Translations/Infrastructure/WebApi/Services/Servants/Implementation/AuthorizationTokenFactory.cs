using System;
using System.Threading.Tasks;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.Settings.Services;
using Mmu.Mlh.RestExtensions.Areas.Models;
using Mmu.Mlh.RestExtensions.Areas.RestProxies;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Servants.Implementation
{
    internal class AuthorizationTokenFactory : IAuthorizationTokenFactory
    {
        private const string OcpApimSubscriptionKeyHeader = "Ocp-Apim-Subscription-Key";
        private readonly IRestProxy _restProxy;
        private readonly Uri _serviceUrl = new Uri("https://api.cognitive.microsoft.com/sts/v1.0/issueToken");
        private readonly ITranslationServiceSettingsProvider _settingsProvider;
        private readonly IAuthorizationTokenCache _tokenCache;

        public AuthorizationTokenFactory(
            IAuthorizationTokenCache tokenCache,
            ITranslationServiceSettingsProvider settingsProvider,
            IRestProxy restProxy)
        {
            _tokenCache = tokenCache;
            _settingsProvider = settingsProvider;
            _restProxy = restProxy;
        }

        public async Task<string> CreateAuthorizationTokenAsync()
        {
            if (_tokenCache.TryGetToken(out var token))
            {
                return token;
            }

            var newToken = await FetchTokenAsync();
            _tokenCache.RefreshToken(newToken);

            return newToken;
        }

        private async Task<string> FetchTokenAsync()
        {
            var token = await _restProxy.PerformCallAsync<string>(
                config => config
                    .StartBuilding(_serviceUrl, RestCallMethodType.Post)
                    .WithHeaders()
                    .AddHeader(OcpApimSubscriptionKeyHeader, _settingsProvider.ProvideSettings().TranslateApiSubscriptionKey)
                    .BuildHeaders()
                    .Build());

            var result = "Bearer " + token;
            return result;
        }
    }
}