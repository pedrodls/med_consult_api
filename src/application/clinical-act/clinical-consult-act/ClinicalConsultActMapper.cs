using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class ClinicalConsultActMapper : IMapper<ClinicalConsultAct, ClinicalConsultActDTO>
{
    public ClinicalConsultAct MapToEntity(ClinicalConsultActDTO dto)
    {
        return new ClinicalConsultAct(
            dto.ConsultId,
            dto.ProfessionalId,
            dto.SubsystemHealthId,
            dto.Id,
            dto.IsActive,
            dto.IsDeleted,
            dto.CreatedAt,
            dto.UpdatedAt,
            dto.DeletedAt
        );
    }

    public ClinicalConsultActDTO MapToDTO(ClinicalConsultAct entity)
    {
        return new ClinicalConsultActDTO
        {
            ConsultId = entity.ConsultId,
            ProfessionalId = entity.ProfessionalId,
            SubsystemHealthId = entity.SubsystemHealthId,
            Id = entity.Id,
            IsActive = entity.IsActive,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt
        };
    }


}