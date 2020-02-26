using System.Collections.Specialized;

namespace PremiumCalculator.AgeRange
{
    class AgeRangeLessThanOrEqualToThirty : BaseAgeRange, IAgeRange
    {
        private OrderedDictionary dictionary = new OrderedDictionary(){
              {Constants.SUM_ASSURED_TWENTY_FIVE_THOUSAND, 0.0172M},
              {Constants.SUM_ASSURED_FIFTY_THOUSAND, 0.0165M},
              {Constants.SUM_ASSURED_HUNDRED_THOUSAND, 0.0154M},
              {Constants.SUM_ASSURED_TWO_HUNDRED_THOUSAND, 0.0147M},
              {Constants.SUM_ASSURED_THREE_HUNDRED_THOUSAND, 0.0144M},
              {Constants.SUM_ASSURED_FIVE_HUNDRED_THOUSAND, 0.0146M}
           };

        private const int maxSumAssured = Constants.SUM_ASSURED_FIVE_HUNDRED_THOUSAND;

        decimal IAgeRange.getRiskRate(int age, int sumAssured)
        {
            return base.getRiskRate(age, sumAssured, maxSumAssured, dictionary);
        }
    }
}
