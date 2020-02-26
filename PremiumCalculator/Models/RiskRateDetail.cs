namespace PremiumCalculator.RiskRate
{
    class RiskRateDetail
    {
        public RiskRateDetail(
            int sumAssured,
            int lowerBandSumAssured,
            decimal lowerBandRiskRate,
            int upperBandSumAssured,
            decimal upperBandRiskRate
        )
        {
            SumAssured = sumAssured;
            LowerBandSumAssured = lowerBandSumAssured;
            LowerBandRiskRateValue = lowerBandRiskRate;
            UpperBandSumAssured = upperBandSumAssured;
            UpperBandRiskRateValue = upperBandRiskRate;
        }

        public int SumAssured { get; set; }

        public int LowerBandSumAssured { get; set; }

        public decimal LowerBandRiskRateValue { get; set; }

        public int UpperBandSumAssured { get; set; }

        public decimal UpperBandRiskRateValue { get; set; }
    }
}

