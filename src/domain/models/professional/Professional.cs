namespace med_consult_api.src.domain;

public class Professional : DomainModel
{
    public Guid UserProfileId { get; private set; }
    public UserProfile? UserProfile { get; private set; }
    public Speciality? Speciality { get; private set; }
    public Guid? SpecialityId { get; private set; }

    public Professional(Guid UserProfileId)
        : base()
    {
        this.UserProfileId = UserProfileId;
    }

    public Professional(
           Guid UserProfileId,
           Guid? id,
           bool? isActive,
           bool? isDeleted,
           DateTime? createdAt,
           DateTime? updatedAt,
           DateTime? deletedAt
       ) : base(id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        this.UserProfileId = UserProfileId;
    }

}