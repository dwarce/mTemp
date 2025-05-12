using System.ComponentModel.DataAnnotations;

namespace mTemp_API.Adapters.DTO
{
/// <summary>
/// Represents a patient.
/// </summary>
    public class PatientDTO
    {
        /// <summary>Patient unique id, generated automatically</summary>
        public int Id { get; set; }

        /// <summary>The patient's first name.</summary>
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; } = string.Empty;
        
        /// <summary>The patient's last name.</summary>
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; } = string.Empty;
        
        /// <summary>The patient's email.</summary>
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string email { get; set; } = string.Empty;

    }
}