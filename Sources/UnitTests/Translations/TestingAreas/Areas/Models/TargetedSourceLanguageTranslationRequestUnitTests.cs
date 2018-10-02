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

            CtorTestBuilderFactory.ForType<TargetedSourceLanguageTranslationRequest>()
                .ForDefaultConstructor()
                .WithArgumentValues(null, targetLanguageCodes, textParts).Fails()
                .WithArgumentValues(sourceLanguageCodes, null, textParts).Fails()
                .WithArgumentValues(sourceLanguageCodes, targetLanguageCodes, null).Fails()
                .WithArgumentValues(sourceLanguageCodes, targetLanguageCodes, textParts)
                .MapsToProperty(f => f.TargetLanguageCodes).WithValue(targetLanguageCodes)
                .MapsToProperty(f => f.TextParts).WithValue(textParts)
                .MapsToProperty(f => f.SourceLanguageCodes).WithValue(sourceLanguageCodes)
                .Succeeds()
                .Build()
                .Assert();
        }
    }
}