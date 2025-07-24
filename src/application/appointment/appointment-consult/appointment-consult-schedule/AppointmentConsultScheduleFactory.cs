using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AppointmentConsultScheduleFactory : IFactory<AppointmentConsultSchedule, CreateAppointmentConsultScheduleDTO, UpdateAppointmentConsultScheduleDTO>
{
    public AppointmentConsultSchedule Create(CreateAppointmentConsultScheduleDTO dto)
    {
        Validate(dto.AppointmentConsultRequestId.ToString(), "AppointmentConsultRequestId");
        Validate(dto.Date.ToString(), "Date");
        Validate(dto.Observations, "Observations");
        Validate(dto.AdministrativeId.ToString(), "AdministrativeId");

        return new AppointmentConsultSchedule(dto.AppointmentConsultRequestId, dto.Date, dto.Observations, dto.AdministrativeId);
    }

    public AppointmentConsultSchedule Update(AppointmentConsultSchedule entity, UpdateAppointmentConsultScheduleDTO updateDTO)
    {
        if (updateDTO.AppointmentConsultRequestId.ToString() is not null)
            Validate(updateDTO.AppointmentConsultRequestId.ToString(), "AppointmentConsultRequestId");

        if (updateDTO.Date is not null)
            Validate(updateDTO.Date.ToString(), "Date");

        if (updateDTO.Observations is not null)
            Validate(updateDTO.Observations.ToString(), "Observations");

        if (updateDTO.AdministrativeId.ToString() is not null)
            Validate(updateDTO.AdministrativeId.ToString(), "AdministrativeId");

        entity.AppointmentConsultRequestId = updateDTO.AppointmentConsultRequestId ?? entity.AppointmentConsultRequestId;

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
