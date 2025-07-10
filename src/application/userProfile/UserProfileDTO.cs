namespace med_consult_api.src.application;

public class UserProfileDTO : Dto
{
    public required string Avatar { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public required DateTime Birthdate { get; set; }
    public required string Gender { get; set; }

    public required string Telephone { get; set; }
    public required string Email { get; set; }

    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }

    public Guid? AuthUserId { get; set; }


}
