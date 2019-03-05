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

            ConstructorTestBuilderFactory.Constructing<DetectedLanguage>()
                .UsingDefaultConstructor()
                .WithArgumentValues(null, AccuracyBetweenOneAndZero).Fails()
                .WithArgumentValues(LanguageCode, AccuracyBetweenOneAndZero)
                .Maps()
                .ToProperty(f => f.AccuracyBetweenOneAndZero).WithValue(AccuracyBetweenOneAndZero)
                .ToProperty(f => f.LanguageCode).WithValue(LanguageCode)
                .BuildMaps()
                .Assert();
        }
    }
}