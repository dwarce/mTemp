using Moq;
using mTemp_API.Domain.Models;
using mTemp_API.Domain.Repositories;
using mTemp_API.Domain.Services.Implementations;
using mTemp_API.Domain.Exceptions;

namespace mTemp_API.Test
{
    public class UnitTests
    {
        private readonly Mock<IPatientsRepository> _mockPatientsRepository;
        private readonly Mock<ITemperatureMeasurementsRepository> _mockTemperatureMeasurementsRepository;
        private readonly TemperatureMeasurementService _measurementService;
        private readonly PatientService _patientService;

        public UnitTests()
        {
            _mockPatientsRepository = new Mock<IPatientsRepository>();
            _mockTemperatureMeasurementsRepository = new Mock<ITemperatureMeasurementsRepository>();
            _measurementService = new TemperatureMeasurementService(
                _mockPatientsRepository.Object,
                _mockTemperatureMeasurementsRepository.Object
            );
            _patientService = new PatientService(_mockPatientsRepository.Object);
        }

        ///<summary>
        /// Tests the GetAllPatients method
        ///</summary
        [Fact]
        public void GetAllPatients_ShouldReturnAllPatients()
        {
            // Arrange
            var patients = new List<Patient>
        {
            new Patient { Id = 1, Email = "john@example.com", FirstName = "John", LastName = "Doe" },
            new Patient { Id = 2, Email = "jane@example.com", FirstName = "Jane", LastName = "Smith" }
        };

            _mockPatientsRepository
                .Setup(repo => repo.GetAllPatients())
                .Returns(patients);

            // Act
            var result = _patientService.GetAllPatients();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, p => p.Email == "john@example.com");
            Assert.Contains(result, p => p.Email == "jane@example.com");
        }

        ///<summary>
        /// Tests the AddPatient method
        ///</summary
        [Fact]
        public void AddPatient_ShouldAddPatient_WhenDataIsValid()
        {
            // Arrange
            var newPatient = new Patient { Email = "new@example.com", FirstName = "John", LastName = "Doe" };

            _mockPatientsRepository
                .Setup(repo => repo.FindPatientByEmail(newPatient.Email))
                .Returns((Patient)null);

            _mockPatientsRepository
                .Setup(repo => repo.AddPatient(newPatient))
                .Returns(newPatient);

            // Act
            var result = _patientService.AddPatient(newPatient);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("new@example.com", result.Email);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
        }

        ///<summary>
        /// Tests the InvalidPatientDataException when patient already exists
        ///</summary
        [Fact]
        public void AddPatient_ShouldThrowException_WhenEmailAlreadyExists()
        {
            // Arrange
            var existingPatient = new Patient { Email = "existing@example.com" };
            var newPatient = new Patient { Email = "existing@example.com" };

            _mockPatientsRepository
                .Setup(repo => repo.FindPatientByEmail(newPatient.Email))
                .Returns(existingPatient);

            // Act & Assert
            Assert.Throws<InvalidPatientDataException>(() => _patientService.AddPatient(newPatient));
        }


        ///<summary>
        /// Tests the GetMeasurementsByPatient method when the patient is not found.
        ///</summary>
        [Fact]
        public void GetMeasurementsByPatient_ShouldThrowException_WhenPatientNotFound()
        {
            // Arrange
            int patientId = 1;
            _mockPatientsRepository
                .Setup(repo => repo.GetPatientById(patientId))
                .Returns((Patient)null);

            // Act & Assert
            Assert.Throws<PatientNotFoundException>(() => _measurementService.GetMeasurementsByPatient(patientId));
        }

        ///<summary>
        /// Tests the GetMeasurementsBy id method when the patient exists.
        ///</summary>
        [Fact]
        public void GetMeasurementById_ShouldReturnMeasurement_WhenFound()
        {
            // Arrange
            int measurementId = 1;
            var measurement = new TemperatureMeasurement { MeasuredTemperature = 36.5M, MeasuredMethod = "Infrared" };

            _mockTemperatureMeasurementsRepository
                .Setup(repo => repo.GetMeasurementById(measurementId))
                .Returns(measurement);

            // Act
            var result = _measurementService.GetMeasurementById(measurementId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(36.5M, result.MeasuredTemperature);
        }

        ///<summary>
        /// Tests the validation of temperature measurement (temperature value).
        ///</summary>
        [Fact]
        public void AddMeasurement_ShouldThrowException_WhenMeasurementIsInvalid1()
        {
            // Arrange
            var invalidMeasurement = new TemperatureMeasurement { MeasuredTemperature = 60M }; // Invalid temperature

            // Act & Assert
            Assert.Throws<InvalidTemperatureMeasurementDataException>(() => _measurementService.AddMeasurement(invalidMeasurement));
        }


        ///<summary>
        /// Tests the validation of temperature measurement (measurement method).
        ///</summary>
        [Fact]
        public void AddMeasurement_ShouldThrowException_WhenMeasurementIsInvalid2()
        {
            // Arrange
            var invalidMeasurement = new TemperatureMeasurement { MeasuredTemperature = 36.5M, MeasuredMethod = "Unknown method" }; // Invalid MeasuredMethod

            // Act & Assert
            Assert.Throws<InvalidTemperatureMeasurementDataException>(() => _measurementService.AddMeasurement(invalidMeasurement));
        }


        ///<summary>
        /// Tests the GetMeasurementsByPatient method when the patient exists.
        ///</summary>
        [Fact]
        public void GetMeasurementsByPatient_ShouldReturnMeasurements_WhenPatientExists()
        {
            // Arrange
            int patientId = 1;
            var patient = new Patient { FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com" };
            var measurements = new List<TemperatureMeasurement>
        {
            new TemperatureMeasurement { MeasuredTemperature = 37.5M, PatientId = patientId }
        };

            _mockPatientsRepository
                .Setup(repo => repo.GetPatientById(patientId))
                .Returns(patient);

            _mockTemperatureMeasurementsRepository
                .Setup(repo => repo.GetMeasurementsByPatient(patient))
                .Returns(measurements);

            // Act
            var result = _measurementService.GetMeasurementsByPatient(patientId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(37.5M, result.First().MeasuredTemperature);
        }
    }
}
