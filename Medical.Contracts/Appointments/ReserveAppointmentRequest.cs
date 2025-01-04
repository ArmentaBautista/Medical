namespace Medical.Contracts.Appointments;

public sealed record ReserveAppointmentRequest(
    Guid doctorId,
    Guid patientId,
    DateTime appointmentDate, 
    decimal price);
