using mTemp_API.Domain.Models;

namespace mTemp_API.Domain.Repositories.Implementations
{
    /// <summary>
    /// In-memory implementation of the IPatientsRepository interface.
    /// </summary>
    public class InMemoryPatientsRepository: IPatientsRepository
    {

        private List<Patient> _patients = new() { };


        /// <summary>
        /// Returns all patients in the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> GetAllPatients() => _patients;


        /// <summary>
        /// Returns the patient that matches the id, null if none of the patients match the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Patient? GetPatientById(int id)
        {
            return _patients.Where(p => p.Id == id).FirstOrDefault();
        }


        /// <summary>
        /// Returns the patient that matches the email, null if none of the patients match the email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Patient? FindPatientByEmail(string email)
        {
            return _patients.Where(p => p.Email.Equals(email)).FirstOrDefault();
        }

        /// <summary>
        /// Sanitizes input and persists the patient to the database
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public Patient AddPatient(Patient patient) {
            patient = sanitizePatient(patient);
            patient.Id = findHighestId() + 1;
            _patients.Add(patient);

            return patient;

        }


        /// <returns>current highest patient id</returns>
        private int findHighestId()
        {
            if (_patients.Count == 0)
            {
                return 0;
            }
            return _patients.Max(p => p.Id);
        }

        /// <summary>
        /// Sanitizes the patient data to prevent unwanted characters
        /// </summary>
        /// <returns>the sanitized patient</returns>
        private Patient sanitizePatient(Patient patient)
        {
            patient.FirstName = patient.FirstName.Trim();
            patient.LastName = patient.LastName.Trim();

            //here we would add more sanitization logic, like checking for sql injections, etc.

            return patient;
        }
    }


}

 