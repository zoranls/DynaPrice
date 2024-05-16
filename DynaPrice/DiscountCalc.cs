using System;

namespace DynaPrice
{
    public class DiscountCalc
    {
        public decimal DiscountPercent { get; }
        public DiscountCalc(decimal discount)
        {
            DiscountPercent = discount;
        }
        public decimal CalculateDiscount(decimal price)
        {
            decimal discountAmount = price * (DiscountPercent / 100);
            discountAmount = Math.Round(discountAmount, 2); 
            return discountAmount;
        }

        //ovaj drugi je samo isti metod kao gore samo umest umesto price with VAT stavi samo price
    }
}
