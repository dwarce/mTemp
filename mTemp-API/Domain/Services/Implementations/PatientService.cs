using mTemp_API.Adapters.Util;
using mTemp_API.Domain.Exceptions;
using mTemp_API.Domain.Models;
using mTemp_API.Domain.Repositories;
using System.Xml.Linq;

namespace mTemp_API.Domain.Services.Implementations
{
    /// <summary>
    /// Service for managing patients.
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IPatientsRepository _patientsRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="PatientService"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public PatientService(IPatientsRepository repository)
        {
            _patientsRepository = repository;
        }


        /// <summary>
        /// Creates a new patient in the database, automatically sets the id.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public Patient AddPatient(Patient patient)
        {
            checkValidPatient(patient);
            return _patientsRepository.AddPatient(patient);
        }


        /// <summary>
        /// Returns the patient that matches the id, null if none of the patients match the id
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> GetAllPatients() => _patientsRepository.GetAllPatients();


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