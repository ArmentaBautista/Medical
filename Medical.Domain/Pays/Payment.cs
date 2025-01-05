using Medical.Domain.Abstractions;
using Medical.Domain.Appointments;
using Medical.Domain.Pays.Events;

namespace Medical.Domain.Pays
{
    public class Payment : Entity
    {
        public Guid AppointmentId { get; private set; }
        public Appointment Appointment { get; set; }
        public Amount Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment()
        {
            
        }

        public static Payment Register(Guid appointmentId, decimal amount, DateTime paymentDate)
        {
            if (appointmentId == Guid.Empty)
                throw new ArgumentException("Appoiment ID must be a valid Value.", nameof(appointmentId));

            var payment = new Payment()
            {
                Id = Guid.NewGuid(),
                AppointmentId = appointmentId,
                Amount = new Amount(amount),
                PaymentDate = paymentDate
            };

            payment.RaiseDomainEvent(new PaymentRegisteredDomainEvent(payment.Id));

            return payment;
        }
    }

    public record Amount
    {
        public decimal Value { get; }

        public Amount(decimal value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString("F2");
    }
}
