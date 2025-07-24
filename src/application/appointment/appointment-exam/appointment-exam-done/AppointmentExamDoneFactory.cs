using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AppointmentExamDoneFactory : IFactory<AppointmentExamDone, CreateAppointmentExamDoneDTO, UpdateAppointmentExamDoneDTO>
{
    public AppointmentExamDone Create(CreateAppointmentExamDoneDTO dto)
    {
        Validate(dto.AppointmentExamScheduleId.ToString(), "AppointmentExamScheduleId");
        Validate(dto.Date.ToString(), "Date");
        Validate(dto.Observations, "Observations");
        Validate(dto.AdministrativeId.ToString(), "AdministrativeId");

        return new AppointmentExamDone(dto.AppointmentExamScheduleId, dto.Date, dto.Observations, dto.AdministrativeId);
    }

    public AppointmentExamDone Update(AppointmentExamDone entity, UpdateAppointmentExamDoneDTO updateDTO)
    {
        if (updateDTO.AppointmentExamScheduleId.ToString() is not null)
            Validate(updateDTO.AppointmentExamScheduleId.ToString(), "AppointmentExamScheduleId");

        if (updateDTO.Date is not null)
            Validate(updateDTO.Date.ToString(), "Date");

        if (updateDTO.Observations is not null)
            Validate(updateDTO.Observations.ToString(), "Observations");

        if (updateDTO.AdministrativeId.ToString() is not null)
            Validate(updateDTO.AdministrativeId.ToString(), "AdministrativeId");

        entity.AppointmentExamScheduleId = updateDTO.AppointmentExamScheduleId ?? entity.AppointmentExamScheduleId;

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
