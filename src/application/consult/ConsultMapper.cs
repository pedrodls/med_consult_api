using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class ConsultMapper : IMapper<Consult, ConsultDTO>
{
    public Consult MapToEntity(ConsultDTO dto)
    {
        return new Consult(
            dto.Name,
            dto.Description,
            dto.SpecialityId,
            dto.Id,
            dto.IsActive,
            dto.IsDeleted,
            dto.CreatedAt,
            dto.UpdatedAt,
            dto.DeletedAt
        );
    }

    public ConsultDTO MapToDTO(Consult entity)
    {
        return new ConsultDTO
        {
            Name = entity.Name,
            Description = entity.Description,
            SpecialityId = entity.SpecialityId,
            Id = entity.Id,
            IsActive = entity.IsActive,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt
        };
    }


}