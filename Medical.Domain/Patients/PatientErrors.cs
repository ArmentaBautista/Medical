using Medical.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Patients
{
    public static class PatientErrors
    {
        public static Error NotFound = new Error("Patient.Found", "The Patient was not found");
        public static Error InvalidCredentials = new Error("Patient.InvalidCredentials",
            "The Patient credentials were not valid");
    }
}
