using Medical.Domain.Abstractions;

namespace Medical.Domain.Pays;

public static class PaymentErrors
{
    public static Error NotFound = new Error("Payment.Found", "The Payment not was found.");
}