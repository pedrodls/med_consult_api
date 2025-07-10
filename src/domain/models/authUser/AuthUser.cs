namespace med_consult_api.src.domain;

public class AuthUser : DomainModel
{
    public string UserName { get; private set; }
    public Password Password { get; private set; }
    public Guid RoleId { get; private set; }
    public Role Role { get; private set; }
    public ResetPasswordCode ResetPasswordCode { get; private set; }
    private AuthUser() { }
    public AuthUser(
        string userName,
        Password password,
        Guid roleId,
        Role role,
        ResetPasswordCode resetPasswordCode

    ) : base()
    {
        UserName = userName;
        Password = password;
        RoleId = roleId;
        Role = role;
        ResetPasswordCode = resetPasswordCode;
    }

    public AuthUser(
       string userName,
       Password password,
       Guid roleId,
       Role role,
       Guid? id,
       ResetPasswordCode resetPasswordCode,
       bool? isActive,
       bool? isDeleted,
       DateTime? createdAt,
       DateTime? updatedAt,
       DateTime? deletedAt
   ) : base(id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        UserName = userName;
        Password = password;
        RoleId = roleId;
        Role = role;
        ResetPasswordCode = resetPasswordCode;
    }

}
