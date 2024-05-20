using System;

namespace DynaPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Object[,] commands = new Object[,]
            {
                //BROJEVI - 1 , STRINGOVI - 2 (DALJE ZA PROVERU INPUTA)
                { "title" , 2, "Product"},
                { "UPC", 2, "Product" },
                { "Price", 1, "Product" },
                { "Currency", 2, "Product" },
                { "Tax Rate", 1, "Report" },
                { "Discount Rate", 1, "Report"},
            };

            //  Object[] contents = new object[commands.Count];
            void consoleCommands(string command)
            {
                Console.WriteLine($"Enter {command}");
                if (true)
                {

                }
                //Console.ReadLine();
            }
            for (int i = 0; i < commands.Length / 3; i++)
            {
                consoleCommands(commands[i, 0].ToString());

            }


            Product product = new Product("book", "12345", 20.25m, "USD");
            ReportGenerator.GenerateReport(product, 20, 15);
        }
    }
}