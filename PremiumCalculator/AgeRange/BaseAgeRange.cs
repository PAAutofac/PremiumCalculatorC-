using PremiumCalculator.RiskRate;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;

namespace PremiumCalculator.AgeRange
{
    public class BaseAgeRange
    {
        private const int minSumAssured = Constants.SUM_ASSURED_TWENTY_FIVE_THOUSAND;

        public decimal getRiskRate(int age, int sumAssured, int maxSumAssured, OrderedDictionary dictionary)
        {
            decimal riskRate = 0.00M;
            if (sumAssured <= maxSumAssured && sumAssured >= minSumAssured && age <= Constants.MAX_AGE_RANGE && age >= Constants.MIN_AGE_RANGE)
            {
                if (isSumAssuredInDictionary(sumAssured, dictionary))
                {
                    riskRate = (decimal) dictionary[(object)sumAssured];
                }
                else
                {
                    riskRate = calculateRiskRate(sumAssured, dictionary);
                }
            }
            return riskRate;
        }

        private bool isSumAssuredInDictionary(int sumAssured, OrderedDictionary dictionary)
        {
            if (dictionary.Contains(sumAssured))
            {
                return true;
            }
            return false;
        }


        private decimal calculateRiskRate(int sumAssured, OrderedDictionary dictionary)
        {
            decimal riskRate;

            RiskRateDetail riskRateDetail = getRiskRateDetail(sumAssured, dictionary);
            decimal lowerBandSumAssured = riskRateDetail.LowerBandSumAssured;
            decimal upperBandSumAssured = riskRateDetail.UpperBandSumAssured;
            decimal lowerBandRiskRate = riskRateDetail.LowerBandRiskRateValue;
            decimal upperBandRiskRate = riskRateDetail.UpperBandRiskRateValue;

            riskRate = ((sumAssured - lowerBandSumAssured) / (upperBandSumAssured - lowerBandSumAssured) * upperBandRiskRate
            + (upperBandSumAssured - sumAssured) / (upperBandSumAssured - lowerBandSumAssured) * lowerBandRiskRate);

            return riskRate;
        }

        private RiskRateDetail getRiskRateDetail(int actualSumAssured, OrderedDictionary dictionary)
        {
            RiskRateDetail riskRateDetail = null;
            for (var index = 0; index < dictionary.Keys.Count; index++)
            {
                int lowerBandSumAssured = (int)dictionary.Cast<DictionaryEntry>().ElementAt(index).Key;
                decimal lowerBandRiskRate = (decimal) dictionary[index];
                int nextIndex = index + 1;
                int upperBandSumAssured = (int)dictionary.Cast<DictionaryEntry>().ElementAt(nextIndex).Key;
                decimal upperBandRiskRate = (decimal) dictionary[nextIndex];

                if (actualSumAssured >= lowerBandSumAssured && actualSumAssured <= upperBandSumAssured)
                {
                    riskRateDetail = new RiskRateDetail(
                            actualSumAssured,
                            lowerBandSumAssured,
                            lowerBandRiskRate,
                            upperBandSumAssured,
                            upperBandRiskRate
                            );
                    break;
                }
            }
            return riskRateDetail;
        }
    }
}
