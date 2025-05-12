
using mTemp_API.Domain.Models;

namespace mTemp_API.Domain.Repositories
{
    /// <summary>
    /// Interface for the TemperatureMeasurements repository.
    /// </summary>
    public interface ITemperatureMeasurementsRepository
    {
        /// <returns>All the temperature measurements in the database - non pageable</returns>
        IEnumerable<TemperatureMeasurement> GetAllMeasurements();
        
        /// <returns>Temperature measurements that match the provided patient id, empty array if none of the measurements are assigned to patient</returns>
        IEnumerable<TemperatureMeasurement> GetMeasurementsByPatient(Patient patient);

        /// <returns>Temperature measurement that matches the id, null if none of the measurements match the id</returns>
        TemperatureMeasurement? GetMeasurementById(int id);
        
        /// <summary>
        /// sanitizes input and persists the temperature measurement to the database
        /// </summary>
        /// <returns>the inserted measurement with the id set</returns>
        TemperatureMeasurement AddMeasurement(TemperatureMeasurement measurement);

        /// <summary>
        /// sanitizes input, sets patient data to measurement and persists the temperature measurement to the database
        /// </summary>
        /// <returns>the inserted measurement with the id  and patientId set</returns>
        TemperatureMeasurement AddPatientMeasurement(Patient patient, TemperatureMeasurement measurement);

    }
}