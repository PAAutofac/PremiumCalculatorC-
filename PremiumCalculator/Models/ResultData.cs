namespace PremiumCalculator.Models
{
    class ResultData
    {
        public ResultData() { }
        public ResultData(int sumAssured, int age, decimal grossPayable)
        {
            SumAssured = sumAssured;
            Age = age;
            GrossPayable = grossPayable;
        }
        public int SumAssured { get; set; }
        public int Age { get; set; }
        public decimal GrossPayable { get; set; }
    }
}
