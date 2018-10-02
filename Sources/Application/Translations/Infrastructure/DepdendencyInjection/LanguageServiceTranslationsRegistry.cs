using Mmu.Mlazh.LanguageService.Translations.Areas.Services;
using Mmu.Mlazh.LanguageService.Translations.Areas.Services.Implementation;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Adapters;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Adapters.Implementation;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Implementation;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Servants;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Services.Servants.Implementation;
using StructureMap;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.DepdendencyInjection
{
    public class LanguageServiceTranslationsRegistry : Registry
    {
        public LanguageServiceTranslationsRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<LanguageServiceTranslationsRegistry>();
                    scanner.WithDefaultConventions();
                });

            For<ITranslationService>().Use<TranslationService>().Singleton();
            For<IAuthorizationTokenFactory>().Use<AuthorizationTokenFactory>().Singleton();
            For<ITranslationApiProxy>().Use<TranslationApiProxy>().Singleton();
            For<IRestCallFactory>().Use<RestCallFactory>().Singleton();
            For<IAuthorizationTokenCache>().Use<AuthorizationTokenCache>().Singleton();
            For<ITranslationResultAdapter>().Use<TranslationResultAdapter>().Singleton();
        }
    }
}