namespace PremiumCalculator.AgeRange
{    class AgeRangeFactory
    {
        public static IAgeRange Build(Enums.AgeRange ageRange)
        {
            switch (ageRange)
            {
                case Enums.AgeRange.LessThanOrEqualToThirty:
                    return new AgeRangeLessThanOrEqualToThirty();
                case Enums.AgeRange.ThirtyOneToFifty:
                    return new AgeRangeThirtyOneToFifty();
                case Enums.AgeRange.AboveFifty:
                default:
                    return new AgeRangeAboveFifty();
            }
        }
    }
}
