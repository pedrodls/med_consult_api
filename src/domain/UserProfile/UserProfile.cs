
namespace med_consult_api.src.domain;

public class UserProfile : DomainModel
{
    public string Avatar { get; private set; }
    public FullName FullName { get; private set; }
    public Birthdate Birthdate { get; private set; }
    public Gender Gender { get; private set; }
    public Telephone Telephone { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public AuthUser? AuthUser { get; private set; }
    public Guid? AuthUserId { get; private set; }

    public UserProfile(
        string avatar,
        FullName fullName,
        Birthdate birthdate,
        Gender gender,
        Telephone telephone,
        Email email,
        Address address,
        AuthUser? authUser,
        Guid ?authUserId) : base()
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