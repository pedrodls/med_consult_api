using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AppointmentConsultDoneMapper : IMapper<AppointmentConsultDone, AppointmentConsultDoneDTO>
{
    public AppointmentConsultDone MapToEntity(AppointmentConsultDoneDTO dto)
    {
        return new AppointmentConsultDone(
            dto.AppointmentConsultScheduleId,
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

    public AppointmentConsultDoneDTO MapToDTO(AppointmentConsultDone entity)
    {
        return new AppointmentConsultDoneDTO
        {
            AdministrativeId = entity.AdministrativeId,
            AppointmentConsultScheduleId = entity.AppointmentConsultScheduleId,
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