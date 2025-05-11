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


        [HttpGet]
        public ActionResult<IEnumerable<TemperatureMeasurementDTO>> GetAllTemperatureMeasurements()
        {
            IEnumerable<TemperatureMeasurementDTO> measurements = _temperatureMeasurementService
                .GetAllMeasurements()
                .Select(ConverterDTO.TemperatureMeasurementToDTO)
                .ToList();
            return Ok(measurements);
        }

        [HttpGet("byPatient")]
        public ActionResult<IEnumerable<TemperatureMeasurementDTO>> GetTemperatureMeasurementsByPatient(int patientId)
        {
            IEnumerable<TemperatureMeasurementDTO> measurements = _temperatureMeasurementService
                .GetMeasurementsByPatient(patientId)
                .Select(ConverterDTO.TemperatureMeasurementToDTO)
                .ToList();
            return Ok(measurements);
        }

        [HttpPost]
        public ActionResult<TemperatureMeasurementDTO> AddTemperatureMeasurement([FromBody] TemperatureMeasurementDTO temperatureMeasurementDTO)
        {
            TemperatureMeasurement measurementToAdd = ConverterDTO.TemperatureMeasurementToDomain(temperatureMeasurementDTO);
            TemperatureMeasurement addedMeasurement = _temperatureMeasurementService.AddMeasurement(measurementToAdd);
            return Ok(ConverterDTO.TemperatureMeasurementToDTO(addedMeasurement));

        }
    }
}
