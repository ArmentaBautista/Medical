using Medical.Domain.CommonRecords;
using Medical.Domain.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Infrastructure.Doctors
{
    internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");
            builder.HasKey(doctor => doctor.Id);

            builder.Property(doctor => doctor.Name)
                .HasMaxLength(32)
                .HasConversion<string>(name => name.CompleteName, value => new Name(value));

            builder.Property(doctor => doctor.LicenseNumber)
                .HasMaxLength(32)
                .HasConversion<string>(x => x.Number, value => new LicenseNumber(value));

            builder.Property(doctor => doctor.Specialty)
                .HasMaxLength(32)
                .HasConversion<string>(x => x.Name, value => new Specialty { Name = value });

        }
    }
}
