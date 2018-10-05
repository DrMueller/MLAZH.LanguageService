using System.Threading.Tasks;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Dtos;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Servants
{
    internal interface ITranslationRestCallFactory
    {
        Task<RestCall> CreateAsync(TranslationRequestDto request);
    }
}