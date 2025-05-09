
using mTemp_API.Domain.Models;

namespace mTemp_API.Domain.Repositories
{
    public interface ITemperatureMeasurementsRepository
    {
        IEnumerable<TemperatureMeasurement> GetAllMeasurements();
        IEnumerable<TemperatureMeasurement> GetMeasurementsByPatient(Patient patient);
        TemperatureMeasurement AddPatientMeasurement(Patient patient, TemperatureMeasurement measurement);

    }
}