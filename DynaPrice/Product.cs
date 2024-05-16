using System;

namespace DynaPrice
{
    public class Product
    {
        public string Name { get; set; }
        public string UPC { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

        public Product(string name, string upc, decimal price, string currency)
        {
            Name = name;
            UPC = upc;
            Price = price;
            Currency = currency;
        }

        public decimal CalcPriceWithTax(decimal taxPercent)
        {
            decimal taxAmount = Price * (taxPercent / 100);
            taxAmount = Math.Round(taxAmount, 2);
            decimal priceWithTax = Price + taxAmount;
            return priceWithTax;
        }
        public decimal CalcPriceWithDiscount(decimal discountPercent)
        {
            DiscountCalc calc = new DiscountCalc(discountPercent);
            decimal discountAmount = calc.CalculateDiscount(Price);
            decimal priceWithDiscount = Price - discountAmount;
            return priceWithDiscount;
        }
        public override string ToString()
        {
            return $"Name:{Name} - UPC:{UPC} - Price:{Price}{Currency} ";
        }
    }
}