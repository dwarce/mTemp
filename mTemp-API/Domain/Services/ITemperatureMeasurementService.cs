using mTemp_API.Domain.Models;

namespace mTemp_API.Domain.Services
{
    public interface ITemperatureMeasurementService
    {
        /// <returns>All the measurements in the database</returns>
        IEnumerable<TemperatureMeasurement> GetAllMeasurements();

        /// <returns>Temperature measurements that match provided patient id</returns>
        IEnumerable<TemperatureMeasurement> GetMeasurementsByPatient(int patientId);

        /// <returns>Temperature measurement that matches provided id</returns>
        TemperatureMeasurement GetMeasurementById(int id);

        /// <summary>
        /// Validates input and creates a new temperature measurement in the database
        /// </summary>
        /// <returns>inserted temperature measurement</returns>
        TemperatureMeasurement AddMeasurement(TemperatureMeasurement measurement);
    }
}