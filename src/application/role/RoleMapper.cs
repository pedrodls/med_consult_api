using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class RoleMapper : IMapper<Role, RoleDTO>
{
    public Role MapToEntity(RoleDTO dto)
    {
        return new Role(
            dto.Name,
            dto.Description,
            dto.Id,
            dto.IsActive,
            dto.IsDeleted,
            dto.CreatedAt,
            dto.UpdatedAt,
            dto.DeletedAt
        );
    }

    public RoleDTO MapToDTO(Role entity)
    {
        return new RoleDTO
        {
            Name = entity.Name,
            Description = entity.Description,
            Id = entity.Id,
            IsActive = entity.IsActive,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt
        };
    }


}