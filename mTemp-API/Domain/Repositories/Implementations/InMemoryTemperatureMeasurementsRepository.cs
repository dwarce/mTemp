using mTemp_API.Domain.Models;

namespace mTemp_API.Domain.Repositories.Implementations
{
    /// <summary>
    /// In-memory implementation of the ITemperatureMeasurementsRepository interface.
    /// </summary>
    public class InMemoryTemperatureMeasurementsRepository : ITemperatureMeasurementsRepository
    {


        private List<TemperatureMeasurement> _measurements = new() { };


        /// <summary>
        /// Returns all temperature measurements in the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TemperatureMeasurement> GetAllMeasurements() => _measurements;


        /// <summary>
        /// Returns the temperature measurements that match the provided patient id, empty array if none of the measurements are assigned to patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public IEnumerable<TemperatureMeasurement> GetMeasurementsByPatient(Patient patient)
        {
            return _measurements.Where(m => m.PatientId == patient.Id);
        }

        /// <summary>
        /// Returns the temperature measurement that matches the id, null if none of the measurements match the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TemperatureMeasurement? GetMeasurementById(int id)
        {
            return _measurements.Where(m => m.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Sanitizes input and persists the temperature measurement to the database
        /// </summary>
        /// <param name="measurement"></param>
        /// <returns></returns>
        public TemperatureMeasurement AddMeasurement(TemperatureMeasurement measurement)
        {
            TemperatureMeasurement sanitizedMeasurement = SanitizeMeasurement(measurement);
            sanitizedMeasurement.Id = FindHighestId() + 1;
            _measurements.Add(sanitizedMeasurement);
            return sanitizedMeasurement;
        }


        /// <summary>
        /// Sanitizes input, sets patient data to measurement and persists the temperature measurement to the database
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="measurement"></param>
        /// <returns></returns>
        public TemperatureMeasurement AddPatientMeasurement(Patient patient, TemperatureMeasurement measurement)
        {
            TemperatureMeasurement sanitizedMeasurement = SanitizeMeasurement(measurement);
            sanitizedMeasurement.PatientId = patient.Id;
            sanitizedMeasurement.Id = FindHighestId() + 1;
            _measurements.Add(sanitizedMeasurement);
            return sanitizedMeasurement;

        }

        /// <returns>current highest measurement id</returns>
        private int FindHighestId()
        {
            if (_measurements.Count == 0)
            {
                return 0;
            }
            return _measurements.Max(m => m.Id);
        }

        /// <summary>
        /// Sanitizes the measurement data to prevent unwanted characters
        /// </summary>
        /// <returns>the sanitized measurement</returns>
        private TemperatureMeasurement SanitizeMeasurement(TemperatureMeasurement measurement)
        {
            measurement.MeasuredMethod = measurement.MeasuredMethod.Trim();
            measurement.MeasuredTemperature = Math.Round(measurement.MeasuredTemperature, 2); // Round to 2 decimal places

            // here we would add more sanitization logic, like checking for sql injections, etc.
            return measurement;
        }



    }

}

 