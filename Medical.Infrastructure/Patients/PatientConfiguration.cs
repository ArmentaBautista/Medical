using Medical.Domain.CommonRecords;
using Medical.Domain.Patients;
using Medical.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Infrastructure.Patients
{
    internal sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(60)
                .HasConversion<string>(p => p.CompleteName, value => new Name(value));

            builder.Property(p => p.Email)
                .HasMaxLength(60)
                .HasConversion<string>(p => p.Value, value => new Domain.CommonRecords.Email(value));

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(60)
                .HasConversion<string>(p => p.Value, value => new PhoneNumber(value));


        }
    }
}
