using mTemp_API.Adapters.DTO;
using mTemp_API.Domain.Models;

namespace mTemp_API.Adapters.Util
{
    public class ConverterDTO
    {
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

        public static PatientDTO PatientToDTO(Patient patient)
        {
            return new PatientDTO
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth
            };

        }

        public static Patient PatientToDomain(PatientDTO dto)
        {
            return new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth
            };
        }
    }
}