namespace mTemp_API.Adapters.DTO
{
    public class TemperatureMeasurementDTO
    {
        public int Id { get; set; } // GUID - Unique identifier.
        public decimal MeasuredTemperature { get; set; } //  The numerical value of the temperature reading.
        public string MeasuredMethod { get; set; } = string.Empty; // The method used for taking the temperature.
        public long Timestamp { get; set; } // When the measurement was recorded in UNIX milliseconds.
        public int PatientId { get; set; } // The ID of the patient associated with this measurement.
    }
}