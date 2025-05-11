namespace mTemp_API.Adapters.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;

    }
}