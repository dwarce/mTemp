using Microsoft.AspNetCore.Mvc;
using mTemp_API.Adapters.DTO;
using mTemp_API.Adapters.Util;
using mTemp_API.Domain.Models;
using mTemp_API.Domain.Services;

namespace mTemp_API.Adapters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController: ControllerBase
    {
        private readonly IPatientService _patientService;


        private readonly ILogger<PatientsController> _logger;

        public PatientsController(ILogger<PatientsController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientDTO>> GetAllPatients()
        {
            IEnumerable<PatientDTO> patientsDTOList = _patientService
                .GetAllPatients()
                .Select(ConverterDTO.PatientToDTO)
                .ToList();
            return Ok(patientsDTOList);
        }

        [HttpPost]
        public ActionResult<PatientDTO> AddPatient([FromBody] PatientDTO patientDTO)
        {
            Patient patientToAdd = ConverterDTO.PatientToDomain(patientDTO);
            Patient addedPatient = _patientService.AddPatient(patientToAdd);
            return Ok(ConverterDTO.PatientToDTO(addedPatient));

        }
    }
}
