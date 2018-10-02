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

            CtorTestBuilderFactory.ForType<TargetedSourceLanguageTranslationResult>()
                .ForDefaultConstructor()
                .WithArgumentValues(null).Fails()
                .WithArgumentValues(translations).Succeeds()
                .WithArgumentValues(translations).MapsToProperty(f => f.Translations).WithValue(translations).Succeeds()
                .Build()
                .Assert();
        }
    }
}