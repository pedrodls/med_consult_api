namespace med_consult_api.src.application;

public class RequestExamDTO : Dto
{
    public required Guid ClinicalExamActId { get; set; }
    public required Guid AppointmentRequestId { get; set; }

}