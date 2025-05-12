namespace mTemp_API.Domain.Models
{
    /// <summary>
    /// Represents a temperature measurement in the system.
    /// </summary>
    public class TemperatureMeasurement
	{
        /// <summary>
        /// Unique identifier for the temperature measurement.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The numerical value of the temperature reading.
        /// </summary>
		public decimal MeasuredTemperature { get; set; }

        /// <summary>
        /// The method used to measure the temperature
        /// </summary>
        public string MeasuredMethod { get; set; } = string.Empty;

        /// <summary>
        /// The time of the measurement.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Foreign key to the Patient table.
        /// </summary>
		public int? PatientId { get; set; } 

	}
}