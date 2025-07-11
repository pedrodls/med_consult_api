using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class RequestExamFactory : IFactory<RequestExam, CreateRequestExamDTO, UpdateRequestExamDTO>
{
    public RequestExam Create(CreateRequestExamDTO dto)
    {
        return new RequestExam(dto.ClinicalExamActId, dto.AppointmentRequestId);
    }

    public RequestExam Update(RequestExam entity, UpdateRequestExamDTO updateDTO)
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
