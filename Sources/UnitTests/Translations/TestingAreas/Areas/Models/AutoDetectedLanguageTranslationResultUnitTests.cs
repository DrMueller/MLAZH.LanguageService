using System.Collections.Generic;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using NUnit.Framework;

namespace Mmu.Mlazh.LanguageService.UnitTests.Translations.TestingAreas.Areas.Models
{
    [TestFixture]
    public class AutoDetectedLanguageTranslationResultUnitTests
    {
        [Test]
        public void Constructor_Works()
        {
            var targetLanguageCodes = new List<string> { "en" };
            var textParts = new List<string> { "Hello" };

            CtorTestBuilderFactory.ForType<AutoDetectLanguageTranslationRequest>()
                .ForDefaultConstructor()
                .WithArgumentValues(targetLanguageCodes, null).Fails()
                .WithArgumentValues(null, textParts).Fails()
                .WithArgumentValues(targetLanguageCodes, textParts).Succeeds()
                .WithArgumentValues(targetLanguageCodes, textParts)
                .MapsToProperty(f => f.TargetLanguageCodes).WithValue(targetLanguageCodes)
                .MapsToProperty(f => f.TextParts).WithValue(textParts)
                .Succeeds()
                .Build()
                .Assert();
        }
    }
}