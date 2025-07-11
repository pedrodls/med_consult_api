using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class RequestExamMapper : IMapper<RequestExam, RequestExamDTO>
{
    public RequestExam MapToEntity(RequestExamDTO dto)
    {
        return new RequestExam(
            dto.ClinicalExamActId,
            dto.AppointmentRequestId,
            dto.Id,
            dto.IsActive,
            dto.IsDeleted,
            dto.CreatedAt,
            dto.UpdatedAt,
            dto.DeletedAt
        );
    }

    public RequestExamDTO MapToDTO(RequestExam entity)
    {
        return new RequestExamDTO
        {
            ClinicalExamActId = entity.ClinicalExamActId,
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