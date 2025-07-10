using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class UserProfileMapper : IMapper<UserProfile, UserProfileDTO>
{
    public UserProfile MapToEntity(UserProfileDTO dto)
    {
        var fullName = new FullName(dto.FirstName, dto.LastName);
        var birthdate = new Birthdate(dto.Birthdate);
        var gender = new Gender(dto.Gender);
        var telephone = new Telephone(dto.Telephone);
        var email = new Email(dto.Email);
        var address = new Address(dto.Street, dto.City, dto.State);

        return new UserProfile(
            avatar: dto.Avatar,
            fullName: fullName,
            birthdate: birthdate,
            gender: gender,
            telephone: telephone,
            email: email,
            address: address,
            id: dto.Id,
            isActive: dto.IsActive,
            isDeleted: dto.IsDeleted,
            createdAt: dto.CreatedAt,
            updatedAt: dto.UpdatedAt,
            deletedAt: dto.DeletedAt
        );
    }

    public UserProfileDTO MapToDTO(UserProfile entity)
    {
        return new UserProfileDTO
        {
            Id = entity.Id,
            IsActive = entity.IsActive,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,

            Avatar = entity.Avatar,
            FirstName = entity.FullName.FirstName,
            LastName = entity.FullName.LastName,
            Birthdate = entity.Birthdate.Date,
            Gender = entity.Gender.value.ToString(),
            Telephone = entity.Telephone.Value,
            Email = entity.Email.Value,
            Street = entity.Address.Street,
            City = entity.Address.City,
            State = entity.Address.State,
        };
    }
}
