using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class RoleFactory : IFactory<Role, CreateRoleDTO>
{
    public Role Create(CreateRoleDTO dto)
    {
        return new Role
         (
             dto.Name,
             dto.Description
         );
    }
}