using Medical.Domain.Appointments;
using Medical.Infrastructure.Shared;

namespace Medical.Infrastructure.Appointments
{
    internal sealed class AppointmentRepository(ApplicationDbContext context)
        : RepositoryBase<Appointment>(context), IAppointmentRepository
    {

        public Task<IEnumerable<Appointment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Update(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
