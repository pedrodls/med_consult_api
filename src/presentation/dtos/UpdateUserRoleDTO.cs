namespace med_consult_api.src.presentation;

public class UpdateUserRoleDTO
{
    public required Guid RoleId { get; set; }
    public required Guid AuthUserId { get; set; }
    
}
