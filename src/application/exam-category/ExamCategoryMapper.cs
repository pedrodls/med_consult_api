using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class ExamCategoryMapper : IMapper<ExamCategory, ExamCategoryDTO>
{
    public ExamCategory MapToEntity(ExamCategoryDTO dto)
    {
        return new ExamCategory(
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

    public ExamCategoryDTO MapToDTO(ExamCategory entity)
    {
        return new ExamCategoryDTO
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