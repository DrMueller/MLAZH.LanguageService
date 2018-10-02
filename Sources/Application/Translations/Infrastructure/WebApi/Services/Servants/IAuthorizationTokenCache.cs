namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Servants
{
    internal interface IAuthorizationTokenCache
    {
        void RefreshToken(string token);

        bool TryGetToken(out string token);
    }
}