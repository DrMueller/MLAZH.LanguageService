using System.Collections.Generic;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using NUnit.Framework;

namespace Mmu.Mlazh.LanguageService.UnitTests.Translations.TestingAreas.Areas.Models
{
    [TestFixture]
    public class TargetedSourceLanguageTranslationRequestUnitTests
    {
        [Test]
        public void Constructor_Works()
        {
            var targetLanguageCodes = new List<string> { "en", "de" };
            var sourceLanguageCodes = new List<string> { "zh", "fr" };
            var textParts = new List<string> { "Hello" };

            ConstructorTestBuilderFactory.Constructing<TargetedSourceLanguageTranslationRequest>()
                .UsingDefaultConstructor()
                .WithArgumentValues(null, targetLanguageCodes, textParts).Fails()
                .WithArgumentValues(sourceLanguageCodes, null, textParts).Fails()
                .WithArgumentValues(sourceLanguageCodes, targetLanguageCodes, null).Fails()
                .WithArgumentValues(sourceLanguageCodes, targetLanguageCodes, textParts)
                .Maps()
                    .ToProperty(f => f.TargetLanguageCodes).WithValue(targetLanguageCodes)
                    .ToProperty(f => f.TextParts).WithValue(textParts)
                    .ToProperty(f => f.SourceLanguageCodes).WithValue(sourceLanguageCodes)
                .BuildMaps()
                .Assert();
        }
    }
}