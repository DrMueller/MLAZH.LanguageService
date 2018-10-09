using System.Collections.Generic;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using NUnit.Framework;

namespace Mmu.Mlazh.LanguageService.UnitTests.Translations.TestingAreas.Areas.Models
{
    public class TargetedSourceLanguageTranslationResultUnitTests
    {
        [Test]
        public void Constructor_Works()
        {
            var translations = new List<Translation>
            {
                new Translation("Test", "en")
            };

            ConstructorTestBuilderFactory.Constructing<TargetedSourceLanguageTranslationResult>()
                .UsingDefaultConstructor()
                .WithArgumentValues(null).Fails()
                .WithArgumentValues(translations).Succeeds()
                .WithArgumentValues(translations).Maps()
                .ToProperty(f => f.Translations).WithValue(translations)
                .Build()
                .Assert();
        }
    }
}