namespace med_consult_api.src.application;

public class UpdateAuthUserDTO : UpdateDTO
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public Guid? RoleId { get; set; }

}