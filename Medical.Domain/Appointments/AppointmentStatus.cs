using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Appointments
{
    public enum AppointmentStatus
    {
        Reserved = 1,
        Rescheduled = 2,
        Cancelled = 3
    }
}
