using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AuthUserFactory : IFactory<AuthUser, CreateAuthUserDTO, UpdateAuthUserDTO>
{
    public AuthUser Create(CreateAuthUserDTO dto)
    {
        Validate(dto.UserName, "Nome do usuário");
        Validate(dto.Password, "Password");
        Validate(dto.UserProfileId.ToString(), "ID do Perfil");
        Validate(dto.RoleId.ToString(), "Tipo de Conta");

        var password = new Password(dto.Password);

        return new AuthUser(
            userName: dto.UserName,
            password: password,
            userProfileId: dto.UserProfileId,
            roleId: dto.RoleId,
            resetPasswordCode: null
        );
    }

    public AuthUser Update(AuthUser entity, UpdateAuthUserDTO updateDTO)
    {
        if (updateDTO.UserName != null)
        {
            Validate(updateDTO.UserName, "Nome de usuário");
            entity.UserName = updateDTO.UserName;
        }

        if (updateDTO.Password != null)
        {
            Validate(updateDTO.Password, "Password");

            entity.Password = new Password(updateDTO.Password);
        }

        if (updateDTO.RoleId != null)
        {
            Validate(updateDTO.RoleId.ToString(), "Role");

            entity.RoleId = (Guid)updateDTO.RoleId;
        }

        bool state = updateDTO.IsActive ?? entity.IsActive;

        if (state)
            entity.Activate();
        else
            entity.Deactivate();

        entity.Touch();

        return entity;
    }

    private void Validate(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{fieldName} não pode estar vazio.");
    }
}
