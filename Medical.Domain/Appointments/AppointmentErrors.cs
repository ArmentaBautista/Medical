using Medical.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Appointments
{
    public static class AppointmentErrors
    {
        public static Error NotFound = new Error("Appointment.Found", "The Appointment was not found");

    }
}
