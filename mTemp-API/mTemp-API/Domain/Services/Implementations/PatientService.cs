using mTemp_API.Domain.Models;
using mTemp_API.Domain.Repositories;

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


            // check if date of birth is in future
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            if (patient.DateOfBirth.CompareTo(currentDate) < 1)
            {
                throw new ArgumentException("Patient has invalid date of birth");
            }
        }
    }
}