using System.ComponentModel.DataAnnotations;

namespace mTemp_API.Domain.Models
{
    /// <summary>
    /// Represents a patient in the system.
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Unique identifier for the patient.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the patient.
        /// </summary>
        [Required(ErrorMessage = "Patient first name is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "First name must not be empty.")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The last name of the patient.
        /// </summary>
        [Required(ErrorMessage = "Patient last name is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Last name must not be empty.")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// The email address of the patient.
        /// </summary>
        [Required(ErrorMessage = "Patient email is required.")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Emailmust not be empty.")]
        public string Email { get; set; } = string.Empty;


    }
}