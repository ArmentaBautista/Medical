namespace Medical.Contracts.Patients;

public record RegisterPatientRequest(
    string Name,
    string Email,
    string PhoneNumber);