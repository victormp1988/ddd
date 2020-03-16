using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scheduler.Domain.Model
{
    interface IPatientRepository
    {
        Patient GetPatient(int patientId);
    }
}
