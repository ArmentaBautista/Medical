using Medical.Domain.Appointments;
using Medical.Domain.Doctors;
using Medical.Domain.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Infrastructure.Appointments
{
    internal sealed class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");
            builder.HasKey(appointment => appointment.Id);

            builder.HasOne<Doctor>()
                .WithMany()
                .HasForeignKey(appointment => appointment.DoctorId);

            builder.HasOne<Patient>()
                .WithMany()
                .HasForeignKey(appointment => appointment.PatientId);

            builder.Property(appointment => appointment.AppointmentDate);
            builder.Property(appointment => appointment.Status);

            //TODO agregar indices para los fk

        }
    }
}
