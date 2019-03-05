using Mmu.Mlazh.LanguageService.TestConsole.Infrastructure.Settings.Services;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.Settings.Services;
using StructureMap;

namespace Mmu.Mlazh.LanguageService.TestConsole.Infrastructure.DependencyInjection
{
    public class TestConsoleRegistry : Registry
    {
        public TestConsoleRegistry()
        {
            For<ITranslationServiceSettingsProvider>().Use<TranslationServiceSettingsProvider>().Singleton();
        }
    }
}