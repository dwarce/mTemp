using System.ComponentModel.DataAnnotations;

namespace mTemp_API.Domain.Models
{
    public class Patient
    {

        public int Id { get; set; } // GUID - Unique identifier.

        [Required(ErrorMessage = "Patient first name is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "First name must not be empty.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Patient last name is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Last name must not be empty.")]
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Patient date of birth is required.")]
        public required DateOnly DateOfBirth { get; set; }

    }
}