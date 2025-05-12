namespace mTemp_API.Domain.Exceptions;

/// <summary>
/// Exception thrown when a temperature measurement is not found.
/// </summary>
public class TemperatueMeasurementNotFoundException : Exception
{
    /// <summary>
    /// The ID of the temperature measurement that was not found.
    /// </summary>
    public int TemperatureMeasurementId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TemperatueMeasurementNotFoundException"/> class.
    /// </summary>
    /// <param name="id"></param>
    public TemperatueMeasurementNotFoundException(int id): base($"Temperature measurement with id {id} not found.") 
    {
        TemperatureMeasurementId = id;
    }
}