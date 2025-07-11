using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class RequestConsultMapper : IMapper<RequestConsult, RequestConsultDTO>
{
    public RequestConsult MapToEntity(RequestConsultDTO dto)
    {
        return new RequestConsult(
            dto.ClinicalConsultActId,
            dto.AppointmentRequestId,
            dto.Id,
            dto.IsActive,
            dto.IsDeleted,
            dto.CreatedAt,
            dto.UpdatedAt,
            dto.DeletedAt
        );
    }

    public RequestConsultDTO MapToDTO(RequestConsult entity)
    {
        return new RequestConsultDTO
        {
            ClinicalConsultActId = entity.ClinicalConsultActId,
            AppointmentRequestId = entity.AppointmentRequestId,
            Id = entity.Id,
            IsActive = entity.IsActive,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt
        };
    }


}