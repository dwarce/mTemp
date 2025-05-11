namespace mTemp_API.Domain.Exceptions;

public class TemperatueMeasurementNotFoundException : Exception
{
    public int TemperatureMeasurementId { get; }

    public TemperatueMeasurementNotFoundException(int id): base($"Temperature measurement with id {id} not found.") 
    {
        TemperatureMeasurementId = id;
    }
}