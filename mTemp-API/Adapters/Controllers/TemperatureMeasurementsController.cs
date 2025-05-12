using Microsoft.AspNetCore.Mvc;
using mTemp_API.Adapters.DTO;
using mTemp_API.Adapters.Util;
using mTemp_API.Domain.Models;
using mTemp_API.Domain.Services;

namespace mTemp_API.Adapters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureMeasurementController : ControllerBase
    {
        private readonly ITemperatureMeasurementService _temperatureMeasurementService;

        private readonly ILogger<TemperatureMeasurementController> _logger;


        public TemperatureMeasurementController(ILogger<TemperatureMeasurementController> logger, ITemperatureMeasurementService temperatureMeasurementService)
        {
            _logger = logger;
            _temperatureMeasurementService = temperatureMeasurementService;
        }


        /// <summary>
        /// Returns all temperature measurements, inserted in the database.
        /// </summary>
        /// <returns>A list of TemperatureMeasurementDTO objects.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<TemperatureMeasurementDTO>> GetAllTemperatureMeasurements()
        {
            IEnumerable<TemperatureMeasurementDTO> measurements = _temperatureMeasurementService
                .GetAllMeasurements()
                .Select(ConverterDTO.TemperatureMeasurementToDTO)
                .ToList();
            return Ok(measurements);
        }

        /// <summary>
        /// Returns all temperature measurements, assigned to the specified patient in the database.
        /// </summary>
        /// <returns>A list of TemperatureMeasurementDTO objects.</returns>
        [HttpGet("byPatient")]
        public ActionResult<IEnumerable<TemperatureMeasurementDTO>> GetTemperatureMeasurementsByPatient(int patientId)
        {
            IEnumerable<TemperatureMeasurementDTO> measurements = _temperatureMeasurementService
                .GetMeasurementsByPatient(patientId)
                .Select(ConverterDTO.TemperatureMeasurementToDTO)
                .ToList();
            return Ok(measurements);
        }

        /// <summary>
        /// Returns temperature measurement that matches the id.
        /// </summary>
        /// <returns>A single TemperatureMeasurementDTO object</returns>
        [HttpGet("byId")]
        public ActionResult<TemperatureMeasurementDTO> GetTemperatureMeasurementById(int id)
        {
            TemperatureMeasurement measurement = _temperatureMeasurementService.GetMeasurementById(id);
            return Ok(ConverterDTO.TemperatureMeasurementToDTO(measurement));
        }

        /// <summary>
        /// Creates a new temperature measurement in the database. Automatically assigns id and measurement timestamp
        /// </summary>
        /// <returns>A TemperatureMeasurementDTO object representation of inserted measurement</returns>
        [HttpPost]
        public ActionResult<TemperatureMeasurementDTO> AddTemperatureMeasurement([FromBody] TemperatureMeasurementDTO temperatureMeasurementDTO)
        {
            TemperatureMeasurement measurementToAdd = ConverterDTO.TemperatureMeasurementToDomain(temperatureMeasurementDTO);
            TemperatureMeasurement addedMeasurement = _temperatureMeasurementService.AddMeasurement(measurementToAdd);
            return Ok(ConverterDTO.TemperatureMeasurementToDTO(addedMeasurement));

        }
    }
}
