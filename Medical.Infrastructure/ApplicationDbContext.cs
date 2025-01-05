using Medical.Application.Exceptions;
using Medical.Domain.Abstractions;
using MediatR;
using Medical.Domain.Appointments;
using Medical.Domain.Doctors;
using Medical.Domain.Patients;
using Medical.Domain.Pays;
using Microsoft.EntityFrameworkCore;

namespace Medical.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IPublisher publisher;

        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            this.publisher = publisher;
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }    
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);
                await PublishDomainEventsAsync();
                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new PersistenceConcurrencyException("A concurrency exception ocurred in the DB", ex);
            }
        }

        private async Task PublishDomainEventsAsync()
        {
            var domainEvents = ChangeTracker
                .Entries<Entity>()
                .Select(x => x.Entity)
                .SelectMany(x =>
                {
                    var domainEvents = x.GetDomainEvents();
                    x.ClearDomainEvents();
                    return domainEvents;
                })
                .ToList();

            foreach (var domainEvent in domainEvents)
                await publisher.Publish(domainEvent);
        }
    }
}
