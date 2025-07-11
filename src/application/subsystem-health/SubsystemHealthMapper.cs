using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class SubsystemHealthMapper : IMapper<SubsystemHealth, SubsystemHealthDTO>
{
    public SubsystemHealth MapToEntity(SubsystemHealthDTO dto)
    {
        return new SubsystemHealth(
            dto.Name,
            dto.Id,
            dto.IsActive,
            dto.IsDeleted,
            dto.CreatedAt,
            dto.UpdatedAt,
            dto.DeletedAt
        );
    }

    public SubsystemHealthDTO MapToDTO(SubsystemHealth entity)
    {
        return new SubsystemHealthDTO
        {
            Name = entity.Name,
            Id = entity.Id,
            IsActive = entity.IsActive,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt
        };
    }


}