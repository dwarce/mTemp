using System.ComponentModel.DataAnnotations;

namespace mTemp_API.Adapters.DTO
{
    /// <summary>
    /// Represents a Temperature Measurement.
    /// </summary>
    public class TemperatureMeasurementDTO
    {
        /// <summary>Measurement unique id, generated automatically</summary>
        public int Id { get; set; }

        /// <summary>The numerical value of the temperature reading in celsius (decimal). Valid value range is between 0 and 50</summary>
        [Required]
        public decimal MeasuredTemperature { get; set; }

        /// <summary>The method used for taking the temperature (available values: 'Infrared', 'Contact (Axillary)', 'Contact (Oral)', 'Contact (Rectal)'</summary>
        [Required]
        public string MeasuredMethod { get; set; } = string.Empty;

        /// <summary>Time of the measurement in UNIX milliseconds, generated automatically</summary>
        public long Timestamp { get; set; }

        /// <summary>ID of the patient associated with this measurement.</summary>
        public int? PatientId { get; set; }
    }
}