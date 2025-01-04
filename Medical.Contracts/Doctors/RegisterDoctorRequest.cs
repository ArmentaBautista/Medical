namespace Medical.Contracts.Doctors
{
    public sealed record RegisterDoctorRequest(
            Guid Id,
            string Name,
            string LicenseNumber,
            string Specialty
            );

}
