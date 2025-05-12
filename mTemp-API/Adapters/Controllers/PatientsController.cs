using Microsoft.AspNetCore.Mvc;
using mTemp_API.Adapters.DTO;
using mTemp_API.Adapters.Util;
using mTemp_API.Domain.Models;
using mTemp_API.Domain.Services;

namespace mTemp_API.Adapters.Controllers
{

    /// <summary>
    /// Controller for managing patients.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PatientsController: ControllerBase
    {
        private readonly IPatientService _patientService;


        private readonly ILogger<PatientsController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientsController"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="patientService"></param>
        public PatientsController(ILogger<PatientsController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        /// <summary>
        /// Returns all patients, inserted in the database.
        /// </summary>
        /// <returns>A list of PatientDTO objects.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<PatientDTO>> GetAllPatients()
        {
            IEnumerable<PatientDTO> patientsDTOList = _patientService
                .GetAllPatients()
                .Select(ConverterDTO.PatientToDTO)
                .ToList();
            return Ok(patientsDTOList);
        }


        /// <summary>
        /// Creates a new patient in the database, automatically sets the id.
        /// </summary>
        /// <returns>A PatientDTO object representation of inserted Patient</returns>
        [HttpPost]
        public ActionResult<PatientDTO> AddPatient([FromBody] PatientDTO patientDTO)
        {
            Patient patientToAdd = ConverterDTO.PatientToDomain(patientDTO);
            Patient addedPatient = _patientService.AddPatient(patientToAdd);
            return Ok(ConverterDTO.PatientToDTO(addedPatient));

        }
    }
}
