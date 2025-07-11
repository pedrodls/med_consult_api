using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class SpecialityMapper : IMapper<Speciality, SpecialityDTO>
{
    public Speciality MapToEntity(SpecialityDTO dto)
    {
        return new Speciality(
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

    public SpecialityDTO MapToDTO(Speciality entity)
    {
        return new SpecialityDTO
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