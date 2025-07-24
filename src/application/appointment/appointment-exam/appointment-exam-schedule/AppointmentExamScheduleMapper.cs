using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AppointmentExamScheduleMapper : IMapper<AppointmentExamSchedule, AppointmentExamScheduleDTO>
{
    public AppointmentExamSchedule MapToEntity(AppointmentExamScheduleDTO dto)
    {
        return new AppointmentExamSchedule(
            dto.AppointmentExamRequestId,
            dto.Date,
            dto.Observations,
            dto.AdministrativeId,
            dto.Id,
            dto.IsActive,
            dto.IsDeleted,
            dto.CreatedAt,
            dto.UpdatedAt,
            dto.DeletedAt
        );
    }

    public AppointmentExamScheduleDTO MapToDTO(AppointmentExamSchedule entity)
    {
        return new AppointmentExamScheduleDTO
        {
            AdministrativeId = entity.AdministrativeId,
            AppointmentExamRequestId = entity.AppointmentExamRequestId,
            Date = entity.Date,
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