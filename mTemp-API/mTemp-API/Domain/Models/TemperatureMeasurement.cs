namespace mTemp_API.Domain.Models
{

	public class TemperatureMeasurement
	{
		public int Id { get; set; } // GUID - Unique identifier.
		public required decimal MeasuredTemperature { get; set; } //  The numerical value of the temperature reading.
		public required string MeasuredMethod { get; set; } // The method used for taking the temperature.
		public required DateTime Timestamp { get; set; } // When the measurement was recorded.

		public int PatientId { get; set; } // Foreign key to the Patient table.


	}
}