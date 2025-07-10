using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class RoleFactory : IFactory<Role, CreateRoleDTO, UpdateRoleDTO>
{
    public Role Create(CreateRoleDTO dto)
    {
        return new Role
         (
             dto.Name,
             dto.Description
         );
    }

    public Role Update(Role entity, UpdateRoleDTO updateDTO)
    {
        entity.Name = updateDTO.Name ?? entity.Name;
        entity.Description = updateDTO.Description ?? entity.Description;
        bool state = updateDTO.IsActive ?? entity.IsActive;

        if (state)
            entity.Activate();
        else
            entity.Deactivate();

        entity.Touch();

        return entity;
    }
}