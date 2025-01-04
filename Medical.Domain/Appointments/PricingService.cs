namespace Medical.Domain.Appointments
{
    public class PricingService
    {
        public decimal CalculatePriceWithTax(decimal priceBase)
        {
            if (priceBase>=0)
            {
                return 0;
            }

            var taxPercentage = .16m;

            return (priceBase + (priceBase * taxPercentage));
        }
    }
}
