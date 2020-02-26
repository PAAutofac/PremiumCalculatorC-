using PremiumCalculator.Models;
using System;
using PremiumCalculator.GrossPremium;
using PremiumCalculator.AgeRange;

namespace PremiumCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 35;
            int sumAssured = 25000;
            getGrossPayable(age, sumAssured);
        }

        private static ResultData getGrossPayable(int age, int sumAssured)
        {
            Console.WriteLine("Age - " + age + " sumAssured - " + sumAssured);
            ResultData resultData = new ResultData();
            AgeRangeProvider ageRangeProvider = new AgeRangeProvider();
            IAgeRangeProvider iageRangeProvider = ageRangeProvider;
            Enums.AgeRange ageRange = iageRangeProvider.getAgeRange(age);
            
            if (ageRange == Enums.AgeRange.OutOfRange) {
                Console.WriteLine("Age not supported");
                return resultData;
            }

            IAgeRange ageRangeObj = AgeRangeFactory.Build(ageRange);
            decimal riskRate = ageRangeObj.getRiskRate(age, sumAssured);
            Console.WriteLine("RiskRate is : " + riskRate);
            if (riskRate != 0.0M)
            {
                resultData = getGrossPremiumForPositiveRiskRate(age, riskRate, sumAssured);
            }
            else
            {
                Console.WriteLine("Risk rate Not available");
            }
            return resultData;
        }

        private static decimal getGrossPremium(decimal riskRate, int sumAssured)
        {
            GrossPremiumCalculator grossPremiumCalculator = new GrossPremiumCalculator();
            IGrossPremiumCalculator premiumCalculator = grossPremiumCalculator;
            return premiumCalculator.getGrossPremiuim(riskRate, sumAssured);
        }

        private static ResultData getGrossPremiumForPositiveRiskRate(int age,decimal riskRate,int sumAssured) 
        {
            ResultData resultData = new ResultData();
            decimal grossPremium = getGrossPremium(riskRate, sumAssured);
            Console.WriteLine("GrossPremium is : " + grossPremium);

            if (grossPremium < 2)
            {
                getGrossPayable(age, sumAssured + 5000);
            }
            else
            {
                resultData.Age = age;
                resultData.SumAssured = sumAssured;
                resultData.GrossPayable = grossPremium;
            }
            return resultData;
        }
    }
}
