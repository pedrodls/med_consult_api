using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AppointmentExamDoneMapper : IMapper<AppointmentExamDone, AppointmentExamDoneDTO>
{
    public AppointmentExamDone MapToEntity(AppointmentExamDoneDTO dto)
    {
        return new AppointmentExamDone(
            dto.AppointmentExamScheduleId,
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

    public AppointmentExamDoneDTO MapToDTO(AppointmentExamDone entity)
    {
        return new AppointmentExamDoneDTO
        {
            AdministrativeId = entity.AdministrativeId,
            AppointmentExamScheduleId = entity.AppointmentExamScheduleId,
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