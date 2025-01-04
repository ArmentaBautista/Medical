using Medical.Domain.Abstractions;
using Medical.Domain.Appointments;

namespace Medical.Domain.Pays
{
    public class Payment : Entity
    {
        public int AppointmentId { get; set; }
        public required Appointment Appointment { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }

    public record Amount
    {
        public decimal Value { get; }

        public Amount(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(value));
            }
            Value = value;
        }

        public override string ToString() => Value.ToString("F2");
    }
}
