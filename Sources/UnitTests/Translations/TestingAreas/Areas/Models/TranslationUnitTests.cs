using Mmu.Mlazh.LanguageService.Translations.Areas.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using NUnit.Framework;

namespace Mmu.Mlazh.LanguageService.UnitTests.Translations.TestingAreas.Areas.Models
{
    [TestFixture]
    public class TranslationUnitTests
    {
        [Test]
        public void Constructor_Works()
        {
            const string Text = "Hello";
            const string TargetLanguageCode = "En";

            ConstructorTestBuilderFactory.Constructing<Translation>()
                .UsingDefaultConstructor()
                .WithArgumentValues(null, Text).Fails()
                .WithArgumentValues(TargetLanguageCode, null).Succeeds()
                .WithArgumentValues(TargetLanguageCode, Text)
                .Maps()
                .ToProperty(f => f.TargetLanguageCode).WithValue(TargetLanguageCode)
                .ToProperty(f => f.Text).WithValue(Text)
                .Build()
                .Assert();
        }
    }
}