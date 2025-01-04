using Medical.Domain.Pays;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Infrastructure.Pays;

public class PaymentConfiguration:IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");

        builder.HasKey(payment => payment.Id);

        builder.Property(payment => payment.Amount)
            .HasConversion<decimal>(payment=> payment.Value,value=> new Amount(value));
    }
}