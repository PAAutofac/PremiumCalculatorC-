using NUnit.Framework;
using PremiumCalculator.GrossPremium;

namespace PremiumCalculator.UnitTest
{
    [TestFixture]
    class TestGrossPremiumCalculator
    {
        decimal expectedGrossPremium;
        decimal actualGrossPremium;
        decimal riskRate;
        int sumAssured;
        IGrossPremiumCalculator grossPremium;

        [SetUp]
        public void Setup()
        {
            GrossPremiumCalculator grossPremiumCalculator = new GrossPremiumCalculator();
            grossPremium = grossPremiumCalculator;
        }

        [Test]
        public void GetGrossPremiuim_Return_GrossPremium()
        {
            expectedGrossPremium = 1.350845M;
            riskRate = 0.0172M;
            sumAssured = 25000;

            actualGrossPremium = grossPremium.getGrossPremiuim(riskRate,sumAssured);

            Assert.AreEqual(expectedGrossPremium, actualGrossPremium);
        }
    }
}
