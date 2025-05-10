using mTemp_API.Adapters.Util;
using mTemp_API.Domain.Exceptions;
using mTemp_API.Domain.Models;
using mTemp_API.Domain.Repositories;
using System.Xml.Linq;

namespace mTemp_API.Domain.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientsRepository _patientsRepository;


        public PatientService(IPatientsRepository repository)
        {
            _patientsRepository = repository;
        }


        Patient IPatientService.AddPatient(Patient patient)
        {
            checkValidPatient(patient);
            return _patientsRepository.AddPatient(patient);
        }


        IEnumerable<Patient> IPatientService.GetAllPatients() => _patientsRepository.GetAllPatients();


        /// <summary>
        /// This method checks if the patient data is valid 
        /// </summary>
        private void checkValidPatient(Patient patient) {

            Patient? existingPatientWithEmail = _patientsRepository.FindPatientByEmail(patient.Email);
            if (existingPatientWithEmail != null)
            {
                throw new InvalidPatientDataException($"A patient with email {patient.Email} already exists");
            }

        }
    }
}