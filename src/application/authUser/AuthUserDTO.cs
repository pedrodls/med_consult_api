namespace med_consult_api.src.application;

public class AuthUserDTO : Dto
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public string? ResetPasswordCode { get; set; }
    public required Guid RoleId { get; set; }
    public required Guid UserProfileId { get; set; }

}