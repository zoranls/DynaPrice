using System;
using System.Collections.Generic;
using System.Text;

namespace DynaPrice
{
    class CustomerTax
    {
        public static decimal basetax = 20;

       
        public CustomerTax(double basetax)
        {
            var x = basetax * 12312;
            Console.WriteLine(x);
        }

        public decimal CalculateTax(decimal price, decimal taxPercentage)
        {
            // Calculate tax amount
            decimal taxAmount = price * (taxPercentage / 100);
            // Round tax amount to two decimal places
            taxAmount = Math.Round(taxAmount, 2);
            return taxAmount;
        }
    }
}