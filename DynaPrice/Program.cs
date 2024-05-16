using System;

namespace DynaPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Zlato", "1935", 20.25m, "USD");
            void a(){
            Console.WriteLine("Unesite Ime proizvoda:");
            product.Name = Console.ReadLine();
            Console.WriteLine("Unesite UPC proizvoda:");
            product.UPC = Console.ReadLine();
            Console.WriteLine("Unesite Cenu proizvoda:");
            product.Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesite popust proizvoda:");
             try
             {
                a();
                 
             }
             catch (System.Exception e)
             {
                 Console.WriteLine($"Pogresan input {e}");
                 throw;
             }   
            decimal discountPercentage = Convert.ToDecimal(Console.ReadLine()); 
            
            //Generate report with Tax (20%) and NO discount
            decimal taxPercentage = 20;
            ReportGenerator.GenerateReport(product, taxPercentage, discountPercentage);

            //Generate report with Tax (20%) and 15% discount
            ReportGenerator.GenerateReport(product, taxPercentage, discountPercentage);

        }
    }
}}