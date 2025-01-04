using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Medical.Domain.Appointments
{
    public interface IAppointmentRepository
    {
        Task<Appointment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Appointment>> GetAllAsync(CancellationToken cancellationToken = default);
        Task Update(Appointment appointment);
        Task Delete(Guid id);
        void Add(Appointment appointment);
    }
}
