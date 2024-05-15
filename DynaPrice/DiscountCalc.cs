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
            return discountAmount;
        }
    }
}
