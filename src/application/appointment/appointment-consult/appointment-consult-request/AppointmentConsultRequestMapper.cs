using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AppointmentConsultRequestMapper : IMapper<AppointmentConsultRequest, AppointmentConsultRequestDTO>
{
    public AppointmentConsultRequest MapToEntity(AppointmentConsultRequestDTO dto)
    {
        return new AppointmentConsultRequest(
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

    public AppointmentConsultRequestDTO MapToDTO(AppointmentConsultRequest entity)
    {
        return new AppointmentConsultRequestDTO
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