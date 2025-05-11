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

        [Required(ErrorMessage = "Patient email is required.")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Emailmust not be empty.")]
        public string Email { get; set; } = string.Empty;


    }
}