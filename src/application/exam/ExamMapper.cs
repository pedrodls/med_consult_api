using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class ExamMapper : IMapper<Exam, ExamDTO>
{
    public Exam MapToEntity(ExamDTO dto)
    {
        return new Exam(
            dto.Name,
            dto.Description,
            dto.SpecialityId,
            dto.ExamCategoryId,
            dto.Id,
            dto.IsActive,
            dto.IsDeleted,
            dto.CreatedAt,
            dto.UpdatedAt,
            dto.DeletedAt
        );
    }

    public ExamDTO MapToDTO(Exam entity)
    {
        return new ExamDTO
        {
            Name = entity.Name,
            Description = entity.Description,
            ExamCategoryId = entity.ExamCategoryId,
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