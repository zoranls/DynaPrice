using System;

namespace DynaPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("book", "123", 20.25m, "USD");
            ReportGenerator.GenerateReport(product,20,15);
        }
    }
}