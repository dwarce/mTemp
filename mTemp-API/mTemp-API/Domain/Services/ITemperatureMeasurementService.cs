using mTemp_API.Domain.Models;

namespace mTemp_API.Domain.Services
{
    public interface ITemperatureMeasurementService
    {
        /// <returns>All the patients</returns>
        IEnumerable<TemperatureMeasurement> GetAllMeasurements();
        IEnumerable<TemperatureMeasurement> GetMeasurementsByPatient(int patientId);

        /// <summary>
        /// Creates a new temperature measurement in the database
        /// </summary>
        /// <returns>inserted temperature measurement</returns>
        TemperatureMeasurement AddMeasurement(TemperatureMeasurement measurement);
    }
}