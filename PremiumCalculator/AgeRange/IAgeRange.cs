namespace PremiumCalculator.AgeRange
{
    interface IAgeRange
    {
        decimal getRiskRate(int age, int sumAssured);
    }
}
