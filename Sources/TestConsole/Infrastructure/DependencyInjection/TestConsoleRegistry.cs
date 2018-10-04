using System.IO;
using Mmu.Mlazh.LanguageService.TestConsole.Infrastructure.Settings.Models;
using Mmu.Mlazh.LanguageService.TestConsole.Infrastructure.Settings.Services;
using Mmu.Mlazh.LanguageService.Translations.Infrastructure.Settings.Services;
using Mmu.Mlh.NetCoreExtensions.Areas.SettingsProvisioning.Services;
using StructureMap;

namespace Mmu.Mlazh.LanguageService.TestConsole.Infrastructure.DependencyInjection
{
    public class TestConsoleRegistry : Registry
    {
        public TestConsoleRegistry()
        {
            For<ITranslationServiceSettingsProvider>().Use<TranslationServiceSettingsProvider>().Singleton();

            var appSettings = SettingsFactory.CreateSettings<TestConsoleAppSettings>(TestConsoleAppSettings.SectionKey);
            For<TestConsoleAppSettings>().Use(appSettings);
        }
    }
}