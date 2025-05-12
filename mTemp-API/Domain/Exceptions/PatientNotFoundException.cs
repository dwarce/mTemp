namespace mTemp_API.Domain.Exceptions;

/// <summary>
/// Exception thrown when a patient is not found.
/// </summary>
public class PatientNotFoundException : Exception
{
    /// <summary>
    /// The ID of the patient that was not found.
    /// </summary>
    public int PatientId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PatientNotFoundException"/> class.
    /// </summary>
    /// <param name="patientId"></param>
    public PatientNotFoundException(int patientId): base($"Patient with id {patientId} not found.") 
    {
        PatientId = patientId;
    }
}