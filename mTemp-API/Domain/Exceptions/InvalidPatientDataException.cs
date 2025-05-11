namespace mTemp_API.Domain.Exceptions;

public class InvalidPatientDataException : Exception
{
    public InvalidPatientDataException(string message) : base(message){}
}
