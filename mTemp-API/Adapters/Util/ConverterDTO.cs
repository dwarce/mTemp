using mTemp_API.Adapters.DTO;
using mTemp_API.Domain.Models;

namespace mTemp_API.Adapters.Util
{
    /// <summary>
    /// Utility class for converting between domain models and DTOs.
    /// </summary>
    public class ConverterDTO
    {
        /// <summary>
        /// Converts a TemperatureMeasurementDTO to a TemperatureMeasurement domain model.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static TemperatureMeasurement TemperatureMeasurementToDomain(TemperatureMeasurementDTO dto)
        {
            return new TemperatureMeasurement
            {
                Id = dto.Id,
                MeasuredMethod = dto.MeasuredMethod,
                MeasuredTemperature = dto.MeasuredTemperature,
                PatientId = dto.PatientId,
                Timestamp = TimeConverter.FromUnixMilliseconds(dto.Timestamp)
            };
        }

        /// <summary>
        /// Converts a TemperatureMeasurement domain model to a TemperatureMeasurementDTO.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>

        public static TemperatureMeasurementDTO TemperatureMeasurementToDTO(TemperatureMeasurement domain)
        {
            return new TemperatureMeasurementDTO
            {
                Id = domain.Id,
                MeasuredMethod = domain.MeasuredMethod,
                MeasuredTemperature = domain.MeasuredTemperature,
                PatientId = domain.PatientId,
                Timestamp = TimeConverter.ToUnixMilliseconds(domain.Timestamp)

            };
        }

        /// <summary>
        /// Converts a PatientDTO to a Patient domain model.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>

        public static PatientDTO PatientToDTO(Patient patient)
        {
            return new PatientDTO
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                email = patient.Email,
            };

        }

        /// <summary>
        /// Converts a Patient domain model to a PatientDTO.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        public static Patient PatientToDomain(PatientDTO dto)
        {
            return new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.email,
            };
        }
    }
}