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

            CtorTestBuilderFactory.ForType<Translation>()
                .ForDefaultConstructor()
                .WithArgumentValues(null, Text).Fails()
                .WithArgumentValues(TargetLanguageCode, null).Succeeds()
                .WithArgumentValues(TargetLanguageCode, Text)
                .MapsToProperty(f => f.TargetLanguageCode).WithValue(TargetLanguageCode)
                .MapsToProperty(f => f.Text).WithValue(Text)
                .Succeeds()
                .Build()
                .Assert();
        }
    }
}