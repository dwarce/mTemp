namespace mTemp_API.Domain.Exceptions;

public class PatientNotFoundException : Exception
{
    public int PatientId { get; }

    public PatientNotFoundException(int patientId): base($"Patient with id {patientId} not found.") 
    {
        PatientId = patientId;
    }
}