using System.Collections.Specialized;

namespace PremiumCalculator.AgeRange
{
    class AgeRangeThirtyOneToFifty : BaseAgeRange, IAgeRange
    {
        private OrderedDictionary dictionary = new OrderedDictionary(){
              {Constants.SUM_ASSURED_TWENTY_FIVE_THOUSAND, 0.1043M},
              {Constants.SUM_ASSURED_FIFTY_THOUSAND, 0.0999M},
              {Constants.SUM_ASSURED_HUNDRED_THOUSAND, 0.0932M},
              {Constants.SUM_ASSURED_TWO_HUNDRED_THOUSAND, 0.0887M},
              {Constants.SUM_ASSURED_THREE_HUNDRED_THOUSAND, 0.0872M},
              {Constants.SUM_ASSURED_FIVE_HUNDRED_THOUSAND, 0.0M}
           };
        private const int maxSumAssured = Constants.SUM_ASSURED_THREE_HUNDRED_THOUSAND;

        decimal IAgeRange.getRiskRate(int age, int sumAssured)
        {
            return base.getRiskRate(age, sumAssured, maxSumAssured, dictionary);
        }
    }
}
