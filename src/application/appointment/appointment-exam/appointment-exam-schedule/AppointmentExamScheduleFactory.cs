using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AppointmentExamScheduleFactory : IFactory<AppointmentExamSchedule, CreateAppointmentExamScheduleDTO, UpdateAppointmentExamScheduleDTO>
{
    public AppointmentExamSchedule Create(CreateAppointmentExamScheduleDTO dto)
    {
        Validate(dto.AppointmentExamRequestId.ToString(), "AppointmentExamRequestId");
        Validate(dto.Date.ToString(), "Date");
        Validate(dto.Observations, "Observations");
        Validate(dto.AdministrativeId.ToString(), "AdministrativeId");

        return new AppointmentExamSchedule(dto.AppointmentExamRequestId, dto.Date, dto.Observations, dto.AdministrativeId);
    }

    public AppointmentExamSchedule Update(AppointmentExamSchedule entity, UpdateAppointmentExamScheduleDTO updateDTO)
    {
        if (updateDTO.AppointmentExamRequestId.ToString() is not null)
            Validate(updateDTO.AppointmentExamRequestId.ToString(), "AppointmentExamRequestId");

        if (updateDTO.Date is not null)
            Validate(updateDTO.Date.ToString(), "Date");

        if (updateDTO.Observations is not null)
            Validate(updateDTO.Observations.ToString(), "Observations");

        if (updateDTO.AdministrativeId.ToString() is not null)
            Validate(updateDTO.AdministrativeId.ToString(), "AdministrativeId");

        entity.AppointmentExamRequestId = updateDTO.AppointmentExamRequestId ?? entity.AppointmentExamRequestId;

        entity.Date = updateDTO.Date ?? entity.Date;
        entity.Observations = updateDTO.Observations ?? entity.Observations;
        entity.AdministrativeId = updateDTO.AdministrativeId ?? entity.AdministrativeId;


        bool state = updateDTO.IsActive ?? entity.IsActive;

        if (state)
            entity.Activate();
        else
            entity.Deactivate();

        entity.Touch();

        return entity;
    }

    private void Validate(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{fieldName} não pode estar vazio.");
    }
}
