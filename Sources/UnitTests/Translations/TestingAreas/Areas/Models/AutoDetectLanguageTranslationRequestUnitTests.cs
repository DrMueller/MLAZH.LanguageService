using System.Collections.Generic;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using NUnit.Framework;

namespace Mmu.Mlazh.LanguageService.UnitTests.Translations.TestingAreas.Areas.Models
{
    [TestFixture]
    public class AutoDetectLanguageTranslationRequestUnitTests
    {
        [Test]
        public void Constructor_Works()
        {
            var targetLanguageCodes = new List<string> { "en", "de" };
            var textParts = new List<string> { "Hello" };

            ConstructorTestBuilderFactory.Constructing<AutoDetectLanguageTranslationRequest>()
                .UsingDefaultConstructor()
                .WithArgumentValues(targetLanguageCodes, null).Fails()
                .WithArgumentValues(null, textParts).Fails()
                .WithArgumentValues(targetLanguageCodes, textParts)
                .Maps()
                .ToProperty(f => f.TargetLanguageCodes).WithValue(targetLanguageCodes)
                .ToProperty(f => f.TextParts).WithValue(textParts)
                .Build()
                .Assert();
        }
    }
}