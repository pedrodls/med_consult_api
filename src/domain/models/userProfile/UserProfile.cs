
namespace med_consult_api.src.domain;

public class UserProfile : DomainModel
{
    public string Avatar { get; set; }
    public FullName FullName { get; set; }
    public Birthdate Birthdate { get; set; }
    public Gender Gender { get; set; }
    public Telephone Telephone { get; set; }
    public Email Email { get; set; }
    public Address Address { get; set; }
    public AuthUser? AuthUser { get; set; }
    public Guid? AuthUserId { get; set; }

    private UserProfile() { }
    public UserProfile(
        string avatar,
        FullName fullName,
        Birthdate birthdate,
        Gender gender,
        Telephone telephone,
        Email email,
        Address address,
        AuthUser? authUser,
        Guid? authUserId) : base()
    {
        Avatar = avatar;
        FullName = fullName;
        Birthdate = birthdate;
        Gender = gender;
        Telephone = telephone;
        Email = email;
        Address = address;
        AuthUser = authUser;
        AuthUserId = authUserId;
    }

    public UserProfile(
            string avatar,
            FullName fullName,
            Birthdate birthdate,
            Gender gender,
            Telephone telephone,
            Email email,
            Address address,
            AuthUser? authUser,
            Guid? authUserId,
            Guid? id,
            bool? isActive,
            bool? isDeleted,
            DateTime? createdAt,
            DateTime? updatedAt,
            DateTime? deletedAt
        ) : base(id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        Avatar = avatar;
        FullName = fullName;
        Birthdate = birthdate;
        Gender = gender;
        Telephone = telephone;
        Email = email;
        Address = address;
        AuthUser = authUser;
        AuthUserId = authUserId;
    }

}