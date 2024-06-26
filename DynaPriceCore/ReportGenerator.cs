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

            //Calc Selective amount
            decimal UPCpercent(string UPC)
            {
                if (UPC == "12345")
                {
                    return 7;
                }
                Random r = new Random();
                return Convert.ToDecimal(r.Next(2, 25));
            } 
            decimal selectiveAmount = product.CalcSelectivePrice(product.Price, discountPercent, UPCpercent(product.UPC), product.UPC);
            //Calc tax amount
            decimal taxAmount = priceWithTax - product.Price;

            //Calc discount amount
            decimal discountAmount = product.PriceWithTax - priceWithDiscount;

            //Calc Selective amount discount
            decimal selectiveDiscount = product.PriceWithTax - selectiveAmount;

            //Print Report
            Console.WriteLine($"Tax={taxPercent}%, Discount={discountPercent}%");
            Console.WriteLine($"Cost = {product.Price:C}");
            Console.WriteLine($"Tax = {taxAmount:C}");
            Console.WriteLine($"Discounts = {discountAmount:C}");
            Console.WriteLine($"Selective Amount = {selectiveAmount:C}");
            Console.WriteLine($"Selective Discount = {selectiveDiscount:C}");


            if (discountAmount > 0)
            {
                Console.WriteLine($"Price before = {product.Price:C}");
                Console.WriteLine($"TOTAL = {priceWithDiscount:C}");
                Console.WriteLine($"------------------");
            }
            else
            {
                Console.WriteLine("No Discounts!");
                Console.WriteLine($"Price before = {product.Price:C}");
                Console.WriteLine($"TOTAL = {priceWithTax:C}");
                Console.WriteLine($"------------------");

            }
        }
    }
}
