namespace Medical.Contracts.Payments;

public record GetPaymentsByAppointmentIdRequest(Guid appointmentId);