﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DynaPrice
{
    public class ReportGenerator
    {
        public static void GenerateReport(Product product, decimal taxPercent, decimal discountPercent)
        {
            //Calc price with tax
           decimal priceWithTax = product.CalcPriceWithTax(taxPercent);

            //Calc price with discount 
            decimal priceWithDiscount = product.CalcPriceWithDiscount(discountPercent);

            //Calc tax amount
            decimal taxAmount = priceWithTax - product.Price;

            //Calc discount amount
            decimal discountAmount = product.PriceWithTax - priceWithDiscount;

            //Print Report
            Console.WriteLine($"Tax={taxPercent}%, Discount={discountPercent}%");
            Console.WriteLine($"Cost = {product.Price:C}");
            Console.WriteLine($"Tax = {taxAmount:C}");
            Console.WriteLine($"Discounts = {discountAmount:C}");

            if (discountAmount > 0)
            {
                Console.WriteLine($"Price before = {product.Price:C}");
                Console.WriteLine($"TOTAL = {priceWithDiscount:C}");
                Console.WriteLine($"------------------");
            }
            else
            {
                Console.WriteLine($"Price before = {product.Price:C}");
                Console.WriteLine($"TOTAL = {priceWithTax:C}");
                Console.WriteLine($"------------------");

            }
        }
    }
}
