namespace mTemp_API.Domain.Exceptions;

public class InvalidTemperatureMeasurementDataException : Exception
{
    public InvalidTemperatureMeasurementDataException(string message) : base(message) { }
}
