using System.Collections.Specialized;

namespace PremiumCalculator.AgeRange
{
    class AgeRangeAboveFifty : BaseAgeRange, IAgeRange
    {
        private OrderedDictionary dictionary = new OrderedDictionary(){
            {Constants.SUM_ASSURED_TWENTY_FIVE_THOUSAND, 0.2677M},
            {Constants.SUM_ASSURED_FIFTY_THOUSAND, 0.2565M},
            {Constants.SUM_ASSURED_HUNDRED_THOUSAND, 0.2393M},
            {Constants.SUM_ASSURED_TWO_HUNDRED_THOUSAND, 0.2285M},
            {Constants.SUM_ASSURED_THREE_HUNDRED_THOUSAND, 0.0M},
            {Constants.SUM_ASSURED_FIVE_HUNDRED_THOUSAND, 0.0M}
          };
        private const int maxSumAssured = Constants.SUM_ASSURED_TWO_HUNDRED_THOUSAND;
        decimal IAgeRange.getRiskRate(int age, int sumAssured)
        {
            return base.getRiskRate(age, sumAssured, maxSumAssured, dictionary);
        }
    }
}
