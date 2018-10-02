using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Servants.Implementation
{
    internal class AuthorizationTokenFactory : IAuthorizationTokenFactory
    {
        private const string OcpApimSubscriptionKeyHeader = "Ocp-Apim-Subscription-Key";
        private const string SubscriptionKey = "045dc19faafb43afa35dc34e033ef1fe";
        private readonly Uri _serviceUrl = new Uri("https://api.cognitive.microsoft.com/sts/v1.0/issueToken");
        private readonly IAuthorizationTokenCache _tokenCache;

        public AuthorizationTokenFactory(IAuthorizationTokenCache tokenCache)
        {
            _tokenCache = tokenCache;
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
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = _serviceUrl;
                request.Content = new StringContent(string.Empty);
                request.Headers.TryAddWithoutValidation(OcpApimSubscriptionKeyHeader, SubscriptionKey);
                client.Timeout = TimeSpan.FromSeconds(2);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var token = await response.Content.ReadAsStringAsync();
                var result = "Bearer " + token;

                return result;
            }
        }
    }
}