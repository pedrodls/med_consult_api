using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class ClinicalExamActMapper : IMapper<ClinicalExamAct, ClinicalExamActDTO>
{
    public ClinicalExamAct MapToEntity(ClinicalExamActDTO dto)
    {
        return new ClinicalExamAct(
            dto.ExamId,
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

    public ClinicalExamActDTO MapToDTO(ClinicalExamAct entity)
    {
        return new ClinicalExamActDTO
        {
            ExamId = entity.ExamId,
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