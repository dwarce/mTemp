using mTemp_API.Domain.Models;
using mTemp_API.Domain.Repositories;

namespace mTemp_API.Domain.Services.Implementations
{
    public class TemperatureMeasurementService : ITemperatureMeasurementService
    {
        private readonly IPatientsRepository _patientsRepository;
        private readonly ITemperatureMeasurementsRepository _temperatureMeasurementsRepository;


        public TemperatureMeasurementService(IPatientsRepository patientsRepository, ITemperatureMeasurementsRepository temperatureMeasurementsRepository)
        {
            _patientsRepository = patientsRepository;
            _temperatureMeasurementsRepository = temperatureMeasurementsRepository;
        }

        
        public IEnumerable<TemperatureMeasurement> GetMeasurementsByPatient(int patientId)
        {
            Patient? patientById = _patientsRepository.GetPatientById(patientId);
            if (patientById == null)
            {
                throw new ArgumentException("Patient not found");
            }
            return _temperatureMeasurementsRepository.GetMeasurementsByPatient(patientById);
        }


        public IEnumerable<TemperatureMeasurement> GetAllMeasurements()
        {
            return _temperatureMeasurementsRepository.GetAllMeasurements();
        }


        public TemperatureMeasurement AddMeasurement(TemperatureMeasurement measurement)
        {
            Patient? patientById = _patientsRepository.GetPatientById(measurement.PatientId);
            if (patientById == null)
            {
                throw new ArgumentException("Patient not found");
            }

            checkValidMeasurement(measurement);
            measurement.Timestamp = DateTime.UtcNow; // Set to current UTC time

            return _temperatureMeasurementsRepository.AddPatientMeasurement(patientById, measurement);

        }


        /// <summary>
        /// This method checks if the measurement data is valid 
        /// </summary>
        private void checkValidMeasurement(TemperatureMeasurement measurement)
        {
            if (measurement == null)
            {
                throw new ArgumentNullException(nameof(measurement), "Measurement cannot be null");
            }
            if (measurement.MeasuredTemperature < 0 || measurement.MeasuredTemperature > 50)
            {
                throw new ArgumentOutOfRangeException(nameof(measurement.MeasuredTemperature), "Measured temperature must be between 0 and 50 degrees Celsius");
            }
            if (string.IsNullOrWhiteSpace(measurement.MeasuredMethod))
            {
                throw new ArgumentException("Measured method cannot be null or empty");
            }

        }
    }
}