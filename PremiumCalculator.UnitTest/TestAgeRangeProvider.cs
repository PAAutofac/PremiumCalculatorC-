using NUnit.Framework;
using PremiumCalculator.AgeRange;

namespace PremiumCalculator.UnitTest
{
    [TestFixture]
    class TestAgeRangeProvider
    {
        IAgeRangeProvider ageRange;
        Enums.AgeRange expectedAgeRange;
        Enums.AgeRange actualAgeRange;

        [SetUp]
        public void Setup()
        {
            AgeRangeProvider ageRangeProvider = new AgeRangeProvider();
            ageRange = ageRangeProvider;
        }

        [Test]
        public void GetAgeRange_InputIsGreaterThan65_Return_OutOfRange()
        {
            expectedAgeRange = Enums.AgeRange.OutOfRange;

            actualAgeRange = ageRange.getAgeRange(100);

            Assert.AreEqual(expectedAgeRange, actualAgeRange);
        }

        [Test]
        public void GetAgeRange_InputIsLessThan18_Return_OutOfRange()
        {
            expectedAgeRange = Enums.AgeRange.OutOfRange;

            actualAgeRange = ageRange.getAgeRange(10);

            Assert.AreEqual(expectedAgeRange, actualAgeRange);
        }

        [Test]
        public void GetAgeRange_InputIs20_Return_LessThanOrEqualToThirty()
        {
            expectedAgeRange = Enums.AgeRange.LessThanOrEqualToThirty;

            actualAgeRange = ageRange.getAgeRange(20);

            Assert.AreEqual(expectedAgeRange, actualAgeRange);
        }

        [Test]
        public void GetAgeRange_InputIs40_Return_ThirtyOneToFifty()
        {
             expectedAgeRange = Enums.AgeRange.ThirtyOneToFifty;

             actualAgeRange = ageRange.getAgeRange(40);

             Assert.AreEqual(expectedAgeRange, actualAgeRange);
        }

        [Test]
        public void GetAgeRange_InputIs60_Return_AboveFifty()
        {
            expectedAgeRange = Enums.AgeRange.AboveFifty;

            actualAgeRange = ageRange.getAgeRange(60);

            Assert.AreEqual(expectedAgeRange, actualAgeRange);
        }

    }
}
