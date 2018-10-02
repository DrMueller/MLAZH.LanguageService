using System;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Servants.Implementation
{
    internal class AuthorizationTokenCache : IAuthorizationTokenCache
    {
        private readonly TimeSpan _tokenCacheDuration = new TimeSpan(0, 5, 0); // Token lifetime on the server is 10 minutes
        private DateTime _storedTokenTime = DateTime.MinValue;
        private string _tokenCache;

        public void RefreshToken(string token)
        {
            _tokenCache = token;
            _storedTokenTime = DateTime.Now;
        }

        public bool TryGetToken(out string token)
        {
            if (DateTime.Now - _storedTokenTime < _tokenCacheDuration)
            {
                token = _tokenCache;
                return true;
            }

            token = string.Empty;
            return false;
        }
    }
}