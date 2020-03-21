using Ical.Net;
using Scheduler.Domain.Model;
using Scheduler.Domain.Model.PatientAggregate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Scheduler.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly List<Patient> _patientStore;

        public PatientRepository()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\calendar.ics");
            var icalString = File.ReadAllText(path);
            var _calendar = Calendar.Load(icalString);
            _patientStore = new List<Patient>()
            {
                new Patient(1, _calendar)
            };
        }

        public Patient Get(int patientId)
        {
            return _patientStore.FirstOrDefault(patient => patient.Id == patientId);
        }
    }
}