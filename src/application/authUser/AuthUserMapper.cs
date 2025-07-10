using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AuthUserMapper : IMapper<AuthUser, AuthUserDTO>
{
    public AuthUser MapToEntity(AuthUserDTO dto)
    {

        var resetPasswordCode = new ResetPasswordCode(dto.ResetPasswordCode);

        var password = new Password(dto.Password);

        return new AuthUser(
            id: dto.Id,
            roleId: dto.RoleId,
            password: password,
            userName: dto.UserName,
            isActive: dto.IsActive,
            isDeleted: dto.IsDeleted,
            createdAt: dto.CreatedAt,
            updatedAt: dto.UpdatedAt,
            deletedAt: dto.DeletedAt,
            userProfileId: dto.UserProfileId,
            resetPasswordCode: resetPasswordCode
        );
    }

    public AuthUserDTO MapToDTO(AuthUser entity)
    {
        return new AuthUserDTO
        {
            Id = entity.Id,
            IsActive = entity.IsActive,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
            UserProfileId = entity.UserProfileId,
            Password = entity.Password.Value,
            UserName = entity.UserName,
            RoleId = entity.RoleId,
            ResetPasswordCode = entity?.ResetPasswordCode?.Value,
        };
    }


}