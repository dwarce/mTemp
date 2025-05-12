namespace mTemp_API.Domain.Exceptions;

/// <summary>
/// Exception thrown when the patient data is invalid.
/// </summary>
public class InvalidPatientDataException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidPatientDataException"/> class.
    /// </summary>
    public InvalidPatientDataException(string message) : base(message){}
}
