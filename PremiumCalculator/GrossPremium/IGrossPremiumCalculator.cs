namespace PremiumCalculator.GrossPremium
{
   public interface IGrossPremiumCalculator
    {
        public decimal getGrossPremiuim(decimal riskRate, int sumAssured);
    }
}
