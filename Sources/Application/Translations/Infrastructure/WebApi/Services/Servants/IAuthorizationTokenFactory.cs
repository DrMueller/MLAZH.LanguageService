using System.Threading.Tasks;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Servants
{
    internal interface IAuthorizationTokenFactory
    {
        Task<string> CreateAuthorizationTokenAsync();
    }
}