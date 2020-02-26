namespace PremiumCalculator.AgeRange
{
    public class AgeRangeProvider : IAgeRangeProvider
    {
        Enums.AgeRange IAgeRangeProvider.getAgeRange(int age)
        {
            Enums.AgeRange agerange = Enums.AgeRange.OutOfRange;

            if (age >= 18 &&  age <= 30)
            {
                agerange = Enums.AgeRange.LessThanOrEqualToThirty;
            }
            else if (age >= 31 && age <= 50)
            {
                agerange = Enums.AgeRange.ThirtyOneToFifty;
            }
            else if (age >= 50 && age <= 65 )
            {
                agerange = Enums.AgeRange.AboveFifty;
            }

            return agerange;
        }
    }
}
