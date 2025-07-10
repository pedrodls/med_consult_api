namespace med_consult_api.src.domain;

public class AuthUser : DomainModel
{
    public string UserName { get; set; }
    public Password Password { get; set; }
    public Guid RoleId { get; set; }
    public Guid UserProfileId { get; private set; }
    public UserProfile UserProfile { get; private set; }
    public Role Role { get; private set; }
    public ResetPasswordCode? ResetPasswordCode { get; }
    private AuthUser() { }
    public AuthUser(
        string userName,
        Password password,
        Guid roleId,
        Guid userProfileId,
        ResetPasswordCode? resetPasswordCode

    ) : base()
    {
        UserName = userName;
        Password = password;
        RoleId = roleId;
        ResetPasswordCode = resetPasswordCode;
        UserProfileId = userProfileId;
    }

    public AuthUser(
       string userName,
       Password password,
       Guid roleId,
       Guid? id,
       Guid userProfileId,
       ResetPasswordCode? resetPasswordCode,
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
        UserProfileId = userProfileId;
        ResetPasswordCode = resetPasswordCode;
    }

}
