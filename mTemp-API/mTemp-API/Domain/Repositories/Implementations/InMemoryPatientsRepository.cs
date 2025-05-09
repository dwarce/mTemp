using mTemp_API.Domain.Models;

namespace mTemp_API.Domain.Repositories.Implementations
{
    public class InMemoryPatientsRepository: IPatientsRepository
    {

        private List<Patient> _patients = new() { };

        public IEnumerable<Patient> GetAllPatients() => _patients;

        public Patient? GetPatientById(int id)
        {
            return _patients.Where(p => p.Id == id).FirstOrDefault();
        }

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

 