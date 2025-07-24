using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AppointmentConsultDoneFactory : IFactory<AppointmentConsultDone, CreateAppointmentConsultDoneDTO, UpdateAppointmentConsultDoneDTO>
{
    public AppointmentConsultDone Create(CreateAppointmentConsultDoneDTO dto)
    {
        Validate(dto.AppointmentConsultScheduleId.ToString(), "AppointmentConsultScheduleId");
        Validate(dto.Date.ToString(), "Date");
        Validate(dto.Observations, "Observations");
        Validate(dto.AdministrativeId.ToString(), "AdministrativeId");

        return new AppointmentConsultDone(dto.AppointmentConsultScheduleId, dto.Date, dto.Observations, dto.AdministrativeId);
    }

    public AppointmentConsultDone Update(AppointmentConsultDone entity, UpdateAppointmentConsultDoneDTO updateDTO)
    {
        if (updateDTO.AppointmentConsultScheduleId.ToString() is not null)
            Validate(updateDTO.AppointmentConsultScheduleId.ToString(), "AppointmentConsultScheduleId");

        if (updateDTO.Date is not null)
            Validate(updateDTO.Date.ToString(), "Date");

        if (updateDTO.Observations is not null)
            Validate(updateDTO.Observations.ToString(), "Observations");

        if (updateDTO.AdministrativeId.ToString() is not null)
            Validate(updateDTO.AdministrativeId.ToString(), "AdministrativeId");

        entity.AppointmentConsultScheduleId = updateDTO.AppointmentConsultScheduleId ?? entity.AppointmentConsultScheduleId;

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
