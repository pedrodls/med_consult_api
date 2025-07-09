namespace med_consult_api.src.domain;

public class AuthUser : DomainModel
{
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Guid RoleId { get; private set; }
    public Role Role { get; private set; }
    public ResetPasswordCode ResetPasswordCode { get; private set; }

    private AuthUser() { }
    public AuthUser(
        Email email,
        Password password,
        Guid roleId,
        Role role,
        ResetPasswordCode resetPasswordCode

    ) : base()
    {
        Email = email;
        Password = password;
        RoleId = roleId;
        Role = role;
        ResetPasswordCode = resetPasswordCode;
    }

    public AuthUser(
       Email email,
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
        Email = email;
        Password = password;
        RoleId = roleId;
        Role = role;
        ResetPasswordCode = resetPasswordCode;
    }

}
