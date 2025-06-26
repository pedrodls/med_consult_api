namespace med_consult_api.src.domain;

public class AuthUser : DomainModel
{
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Guid RoleId { get; private set; }
    public Role Role { get; private set; }

    public AuthUser(
        Email email,
        Password password,
        Guid roleId,
        Role role
    ) : base()
    {
        Email = email;
        Password = password;
        RoleId = roleId;
        Role = role;
    }

    public AuthUser(
       Email email,
       Password password,
       Guid roleId,
       Role role,
       Guid? id,
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
    }

}
