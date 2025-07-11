using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class ProfessionalMapper : IMapper<Professional, ProfessionalDTO>
{
    public Professional MapToEntity(ProfessionalDTO dto)
    {
        return new Professional(
            dto.UserProfileId,
            dto.SpecialityId,
            dto.Id,
            dto.IsActive,
            dto.IsDeleted,
            dto.CreatedAt,
            dto.UpdatedAt,
            dto.DeletedAt
        );
    }

    public ProfessionalDTO MapToDTO(Professional entity)
    {
        return new ProfessionalDTO
        {
            UserProfileId = entity.UserProfileId,
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