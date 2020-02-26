namespace PremiumCalculator.GrossPremium
{
    public class GrossPremiumCalculator : IGrossPremiumCalculator
    {
        decimal IGrossPremiumCalculator.getGrossPremiuim(decimal riskRate, int sumAssured)
        {
            decimal riskPremium = riskRate * (sumAssured / 1000);

            decimal renewalCommission = 0.03M * riskPremium;

            decimal netPremium = riskPremium + renewalCommission;

            decimal initialCommission = netPremium * 2.05M;

            decimal grossPremium = netPremium + initialCommission;

            return grossPremium;
        }
    }
}
