using System;

namespace DynaPrice
{
    class Program
    {
        static void Main(string[] args)
        {


            static string CheckCurrency(string prompt)
            {
                string[] Currency = { ",USD", ",GBP", ",RSD", ",CHF", ",JPY" };
                //      bool isValidInput = false;
                Console.WriteLine("Avalaible Currencies:");
                Array.ForEach(Currency, Console.Write);
                Console.WriteLine("\n" + prompt);
                string value= Console.ReadLine().ToUpper();
                for (int i = 0; i < Currency.Length; i++)
                {
                    if (value == Currency[i].Remove(0,1))  return value;
                }
                Console.WriteLine("Invalid input. Returned USD instead!");
                return "USD";
            }

            static decimal ReadDecimalFromConsole(string prompt)
            {
                decimal value;
                bool isValidInput = false;
                do
                {
                    Console.Write(prompt);
                    if (decimal.TryParse(Console.ReadLine(), out value))
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid decimal value.");
                    }
                } while (!isValidInput);

                return value;
            }
            Product product = new Product();

            Console.WriteLine("Enter name: ");
            product.Name = Console.ReadLine();

            Console.WriteLine("Enter the product's UPC: ");
            product.UPC = Console.ReadLine();

            product.Price = ReadDecimalFromConsole("Enter price: ");

            product.Currency = CheckCurrency("Enter the product's Currency: ");
             
            decimal taxRate = ReadDecimalFromConsole("Enter TAX rate: ");
            decimal discountRate = ReadDecimalFromConsole("Enter Discount rate: ");
 
            ReportGenerator.GenerateReport(product, taxRate, discountRate);
        }
    }
}