namespace med_consult_api.src.application;

public class UpdateUserProfileDTO : UpdateDTO
{
    public string? Avatar { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? Birthdate { get; set; }

    public string? Gender { get; set; }

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }

}
