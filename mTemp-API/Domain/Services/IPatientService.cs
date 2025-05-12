using mTemp_API.Domain.Models;

namespace mTemp_API.Domain.Services
{
    /// <summary>
    /// Service for managing patients.
    /// </summary>
    public interface IPatientService
    {
        /// <returns>All the patients</returns>
        IEnumerable<Patient> GetAllPatients();

        /// <summary>
        /// Validates input and creates a new patient in the database
        /// </summary>
        /// <returns>the patient with the id set</returns>
        Patient AddPatient(Patient patient);
    }
}