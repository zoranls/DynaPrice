using System;

namespace DynaPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Zlato", "1935", 20.25m, "USD");
                
            //Generate report with Tax (20%) and NO discount
            decimal taxPercentage = 20;
            decimal discountPercentage = 15;
            ReportGenerator.GenerateReport(product, taxPercentage, discountPercentage);

            //Generate report with Tax (20%) and 15% discount
            taxPercentage = 20;
            discountPercentage = 0;
            ReportGenerator.GenerateReport(product, taxPercentage, discountPercentage);

        }
    }
}