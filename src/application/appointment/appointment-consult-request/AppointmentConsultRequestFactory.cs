using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class AppointmentConsultRequestFactory : IFactory<AppointmentConsultRequest, CreateAppointmentConsultRequestDTO, UpdateAppointmentConsultRequestDTO>
{
    public AppointmentConsultRequest Create(CreateAppointmentConsultRequestDTO dto)
    {
        Validate(dto.UserProfileId.ToString(), "ProfileId");
        Validate(dto.StartDate.ToString(), "StartDate");
        Validate(dto.EndDate.ToString(), "EndDate");
        Validate(dto.Observations, "Observations");

        return new AppointmentConsultRequest(dto.UserProfileId, dto.StartDate, dto.EndDate, dto.Observations);
    }

    public AppointmentConsultRequest Update(AppointmentConsultRequest entity, UpdateAppointmentConsultRequestDTO updateDTO)
    {
        if (updateDTO.UserProfileId is not null)
            Validate(updateDTO.UserProfileId.ToString(), "ProfileId");

        if (updateDTO.StartDate is not null)
            Validate(updateDTO.StartDate.ToString(), "StartDate");

        if (updateDTO.EndDate is not null)
            Validate(updateDTO.EndDate.ToString(), "EndDate");

        if (updateDTO.Observations is not null)
            Validate(updateDTO.Observations, "Observations");

        entity.UserProfileId = updateDTO.UserProfileId ?? entity.UserProfileId;
        entity.StartDate = updateDTO.StartDate ?? entity.StartDate;
        entity.EndDate = updateDTO.EndDate ?? entity.EndDate;
        entity.Observations = updateDTO.Observations ?? entity.Observations;


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
