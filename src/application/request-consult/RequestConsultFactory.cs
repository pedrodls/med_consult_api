using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class RequestConsultFactory : IFactory<RequestConsult, CreateRequestConsultDTO, UpdateRequestConsultDTO>
{
    public RequestConsult Create(CreateRequestConsultDTO dto)
    {
        return new RequestConsult(dto.ClinicalConsultActId, dto.AppointmentRequestId);
    }

    public RequestConsult Update(RequestConsult entity, UpdateRequestConsultDTO updateDTO)
    {
        bool state = updateDTO.IsActive ?? entity.IsActive;

        if (state)
            entity.Activate();
        else
            entity.Deactivate();

        entity.Touch();

        return entity;
    }

}
