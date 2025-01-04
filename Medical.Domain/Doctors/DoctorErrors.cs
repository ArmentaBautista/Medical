using Medical.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Doctors
{
    public static class DoctorErrors
    {
        public static Error NotFound = new Error("Doctor.Found", "The Doctor was not found");
        
    }
}
