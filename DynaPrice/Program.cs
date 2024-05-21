using System;

namespace DynaPrice
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.WriteLine("Enter the product's Currency: ");
            product.Currency = Console.ReadLine();

            Console.WriteLine("Enter the product's UPC: ");
            product.UPC = Console.ReadLine();

            decimal taxRate = ReadDecimalFromConsole("Enter TAX rate: ");
            decimal discountRate = ReadDecimalFromConsole("Enter Discount rate: ");

            ReportGenerator.GenerateReport(product, taxRate, discountRate);
        }
    }
}