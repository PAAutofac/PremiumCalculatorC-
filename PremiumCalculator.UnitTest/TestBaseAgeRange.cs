using NUnit.Framework;
using PremiumCalculator.AgeRange;
using System.Collections.Specialized;

namespace PremiumCalculator.UnitTest
{
    [TestFixture]
    public class TestBaseAgeRange
    {
        decimal expectedRiskRate;
        public int age;
        public int sumAssured;
        public int maxSumAssured;
        OrderedDictionary dictionary = new OrderedDictionary(){
                  {Constants.SUM_ASSURED_TWENTY_FIVE_THOUSAND, 0.0172M},
                  {Constants.SUM_ASSURED_FIFTY_THOUSAND, 0.0165M},
                  {Constants.SUM_ASSURED_HUNDRED_THOUSAND, 0.0154M},
                  {Constants.SUM_ASSURED_TWO_HUNDRED_THOUSAND, 0.0147M},
                  {Constants.SUM_ASSURED_THREE_HUNDRED_THOUSAND, 0.0144M},
                  {Constants.SUM_ASSURED_FIVE_HUNDRED_THOUSAND, 0.0146M}
               };

        BaseAgeRange baseAgeRange;

       [SetUp]
        public void Setup()
        {
            baseAgeRange = new BaseAgeRange();
        }


        [Test]
        public void GetRiskRate_SumAssuredLessThanMinSumAssured_Return0()
        {
            expectedRiskRate = 0.00M;
            age = 20;
            sumAssured = 20000;
            maxSumAssured = Constants.SUM_ASSURED_FIVE_HUNDRED_THOUSAND;

            decimal actualRiskRate = baseAgeRange.getRiskRate(age, sumAssured, maxSumAssured, dictionary);

            Assert.AreEqual(expectedRiskRate,actualRiskRate);
        }


        [Test]
        public void GetRiskRate_SumAssuredGreaterThanMaxSumAssured_Return0()
        {
            expectedRiskRate = 0.00M;
            age = 20;
            sumAssured = 600000;
            maxSumAssured = Constants.SUM_ASSURED_FIVE_HUNDRED_THOUSAND;

            decimal actualRiskRate = baseAgeRange.getRiskRate(age, sumAssured, maxSumAssured, dictionary);

            Assert.AreEqual(expectedRiskRate, actualRiskRate);
        }

        [Test]
        public void GetRiskRate_AgeLessThanMinAge_Return0()
        {
            expectedRiskRate = 0.00M;
            age = 10;
            sumAssured = 50000;
            maxSumAssured = Constants.SUM_ASSURED_FIVE_HUNDRED_THOUSAND;

            decimal actualRiskRate = baseAgeRange.getRiskRate(age, sumAssured, maxSumAssured, dictionary);

            Assert.AreEqual(expectedRiskRate, actualRiskRate);
        }

        [Test]
        public void GetRiskRate_AgeGreaterThanMaxAge_Return0()
        {
            expectedRiskRate = 0.00M;
            age = 70;
            sumAssured = 50000;
            maxSumAssured = Constants.SUM_ASSURED_TWO_HUNDRED_THOUSAND;

            decimal actualRiskRate = baseAgeRange.getRiskRate(age, sumAssured, maxSumAssured, dictionary);

            Assert.AreEqual(expectedRiskRate, actualRiskRate);
        }


        [Test]
        public void GetRiskRate_SumAssuredInDictionary_ReturnRiskRate()
        {
            expectedRiskRate = 0.0165M;
            age = 40;
            sumAssured = 50000;
            maxSumAssured = Constants.SUM_ASSURED_THREE_HUNDRED_THOUSAND;

            decimal actualRiskRate = baseAgeRange.getRiskRate(age, sumAssured, maxSumAssured, dictionary);

            Assert.AreEqual(expectedRiskRate, actualRiskRate);
        }

        [Test]
        public void GetRiskRate_SumAssuredNotInDictionary_ReturnCalculatedRiskRate()
        {
            expectedRiskRate = 0.01706M;
            age = 40;
            sumAssured = 30000;
            maxSumAssured = Constants.SUM_ASSURED_THREE_HUNDRED_THOUSAND;

            decimal actualRiskRate = baseAgeRange.getRiskRate(age, sumAssured, maxSumAssured, dictionary);

            Assert.AreEqual(expectedRiskRate, actualRiskRate);
        }
    }
}