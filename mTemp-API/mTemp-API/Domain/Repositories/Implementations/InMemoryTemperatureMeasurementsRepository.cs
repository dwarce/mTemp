using mTemp_API.Domain.Models;

namespace mTemp_API.Domain.Repositories.Implementations
{
    public class InMemoryTemperatureMeasurementsRepository : ITemperatureMeasurementsRepository
    {


        private List<TemperatureMeasurement> _measurements = new() { };



        public IEnumerable<TemperatureMeasurement> GetAllMeasurements() => _measurements;
        public IEnumerable<TemperatureMeasurement> GetMeasurementsByPatient(Patient patient)
        {
            return _measurements.Where(m => m.PatientId == patient.Id);
        }

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

 