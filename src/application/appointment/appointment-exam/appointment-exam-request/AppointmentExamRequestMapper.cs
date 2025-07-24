using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AppointmentExamRequestMapper : IMapper<AppointmentExamRequest, AppointmentExamRequestDTO>
{
    public AppointmentExamRequest MapToEntity(AppointmentExamRequestDTO dto)
    {
        return new AppointmentExamRequest(
            dto.UserProfileId,
            dto.StartDate,
            dto.EndDate,
            dto.Observations,
            dto.Id,
            dto.IsActive,
            dto.IsDeleted,
            dto.CreatedAt,
            dto.UpdatedAt,
            dto.DeletedAt
        );
    }

    public AppointmentExamRequestDTO MapToDTO(AppointmentExamRequest entity)
    {
        return new AppointmentExamRequestDTO
        {
            UserProfileId = entity.UserProfileId,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Observations = entity.Observations,
            Id = entity.Id,
            IsActive = entity.IsActive,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt
        };
    }

}