using mTemp_API.Domain.Models;

namespace mTemp_API.Domain.Repositories
{
    public interface IPatientsRepository
    {
        /// <returns>All the patient in the database - non pageable</returns>
        IEnumerable<Patient> GetAllPatients();


        /// <returns>Patient that matches the id, null if none of the patients match the id</returns>
        Patient? GetPatientById(int id);

        /// <returns>Patient that matches the email, null if none of the patients match the email</returns>
        Patient? FindPatientByEmail(string email);
        
        /// <summary>
        /// sanitizes input and persists the patient to the database
        /// </summary>
        /// <returns>the patient with the id set</returns>
        Patient AddPatient(Patient patient);
    }
}