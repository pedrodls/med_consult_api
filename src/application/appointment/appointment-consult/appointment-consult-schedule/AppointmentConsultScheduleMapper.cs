using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AppointmentConsultScheduleMapper : IMapper<AppointmentConsultSchedule, AppointmentConsultScheduleDTO>
{
    public AppointmentConsultSchedule MapToEntity(AppointmentConsultScheduleDTO dto)
    {
        return new AppointmentConsultSchedule(
            dto.AppointmentConsultRequestId,
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

    public AppointmentConsultScheduleDTO MapToDTO(AppointmentConsultSchedule entity)
    {
        return new AppointmentConsultScheduleDTO
        {
            AdministrativeId = entity.AdministrativeId,
            AppointmentConsultRequestId = entity.AppointmentConsultRequestId,
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