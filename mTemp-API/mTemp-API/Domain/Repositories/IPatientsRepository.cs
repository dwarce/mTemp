using mTemp_API.Domain.Models;

namespace mTemp_API.Domain.Repositories
{
    public interface IPatientsRepository
    {
        /// <returns>All the patient in the database - non pageable</returns>
        IEnumerable<Patient> GetAllPatients();


        /// <returns>Patient that matches the id, null if none of the patients match the id</returns>
        Patient? GetPatientById(int id);
        
        /// <summary>
        /// persists the patient to the database
        /// </summary>
        /// <returns>the patient with the id set</returns>
        Patient AddPatient(Patient patient);
    }
}