using Mmu.Mlazh.LanguageService.Translations.Areas.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using NUnit.Framework;

namespace Mmu.Mlazh.LanguageService.UnitTests.Translations.TestingAreas.Areas.Models
{
    [TestFixture]
    public class DetectedLanguageUnitTests
    {
        [Test]
        public void Constructor_Works()
        {
            const string LanguageCode = "en";
            const float AccuracyBetweenOneAndZero = 0.5F;

            CtorTestBuilderFactory.ForType<DetectedLanguage>()
                .ForDefaultConstructor()
                .WithArgumentValues(null, AccuracyBetweenOneAndZero).Fails()
                .WithArgumentValues(LanguageCode, AccuracyBetweenOneAndZero)
                .MapsToProperty(f => f.AccuracyBetweenOneAndZero).WithValue(AccuracyBetweenOneAndZero)
                .MapsToProperty(f => f.LanguageCode).WithValue(LanguageCode)
                .Succeeds()
                .Build()
                .Assert();
        }
    }
}