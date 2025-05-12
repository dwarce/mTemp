namespace mTemp_API.Domain.Exceptions;

/// <summary>
/// Exception thrown when the temperature measurement data is invalid.
/// </summary>
public class InvalidTemperatureMeasurementDataException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidTemperatureMeasurementDataException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public InvalidTemperatureMeasurementDataException(string message) : base(message) { }
}
