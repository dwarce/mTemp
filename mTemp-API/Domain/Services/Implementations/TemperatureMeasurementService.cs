using mTemp_API.Domain.Exceptions;
using mTemp_API.Domain.Models;
using mTemp_API.Domain.Repositories;

namespace mTemp_API.Domain.Services.Implementations
{
    /// <summary>
    /// Service for managing temperature measurements.
    /// </summary>
    public class TemperatureMeasurementService : ITemperatureMeasurementService
    {
        private readonly IPatientsRepository _patientsRepository;
        private readonly ITemperatureMeasurementsRepository _temperatureMeasurementsRepository;

        private static readonly string[] AllowedMeasuredMethods = new[]
        {
            "Infrared", "Contact (Axillary)", "Contact (Oral)", "Contact (Rectal)"
        };


        /// <summary>
        /// Initializes a new instance of the <see cref="TemperatureMeasurementService"/> class.
        /// </summary>
        /// <param name="patientsRepository"></param>
        /// <param name="temperatureMeasurementsRepository"></param>
        public TemperatureMeasurementService(IPatientsRepository patientsRepository, ITemperatureMeasurementsRepository temperatureMeasurementsRepository)
        {
            _patientsRepository = patientsRepository;
            _temperatureMeasurementsRepository = temperatureMeasurementsRepository;
        }


        /// <summary>
        /// Returns all temperature measurements, assigned to the specified patient in the database.
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        /// <exception cref="PatientNotFoundException"></exception>
        public IEnumerable<TemperatureMeasurement> GetMeasurementsByPatient(int patientId)
        {
            Patient? patientById = _patientsRepository.GetPatientById(patientId);
            if (patientById == null)
            {
                throw new PatientNotFoundException(patientId);
            }
            return _temperatureMeasurementsRepository.GetMeasurementsByPatient(patientById);
        }


        /// <summary>
        /// Returns temperature measurement that matches the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="TemperatueMeasurementNotFoundException"></exception>
        public TemperatureMeasurement GetMeasurementById(int id)
        {
            TemperatureMeasurement? byId = _temperatureMeasurementsRepository.GetMeasurementById(id);
            if (byId == null)
            {
                throw new TemperatueMeasurementNotFoundException(id);
            }
            return byId;

        }


        /// <summary>
        /// Returns all temperature measurements, inserted in the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TemperatureMeasurement> GetAllMeasurements()
        {
            return _temperatureMeasurementsRepository.GetAllMeasurements();
        }


        /// <summary>
        /// Creates a new temperature measurement in the database, automatically sets the id and timestamp.
        /// </summary>
        /// <param name="measurement"></param>
        /// <returns></returns>
        /// <exception cref="PatientNotFoundException"></exception>
        public TemperatureMeasurement AddMeasurement(TemperatureMeasurement measurement)
        {
            checkValidMeasurement(measurement);
            measurement.Timestamp = DateTime.UtcNow; // Set to current UTC time

            // if patient id is set, we check if the patient exists and call the AddPatientMeasurement method, otherwise we call the AddMeasurement method
            if (measurement.PatientId != null) 
            {
                int patientId = measurement.PatientId.Value;

                Patient? patientById = _patientsRepository.GetPatientById(patientId);
                if (patientById == null)
                {
                    throw new PatientNotFoundException(patientId);
                }

                return _temperatureMeasurementsRepository.AddPatientMeasurement(patientById, measurement);
            }

            return _temperatureMeasurementsRepository.AddMeasurement(measurement);



        }


        /// <summary>
        /// This method checks if the measurement data is valid 
        /// </summary>
        private void checkValidMeasurement(TemperatureMeasurement measurement)
        {
            if (measurement == null)
            {
                throw new InvalidTemperatureMeasurementDataException("Measurement cannot be null");
            }
            if (measurement.MeasuredTemperature < 0 || measurement.MeasuredTemperature > 50)
            {
                throw new InvalidTemperatureMeasurementDataException("Measured temperature must be between 0 and 50 degrees Celsius");
            }
            if (string.IsNullOrWhiteSpace(measurement.MeasuredMethod))
            {
                throw new InvalidTemperatureMeasurementDataException("Measured method cannot be null or empty");

            } else if (!AllowedMeasuredMethods.Contains(measurement.MeasuredMethod))
            {
                throw new InvalidTemperatureMeasurementDataException($"Specified measured method {measurement.MeasuredMethod} is not allowed");
            }


        }
    }
}