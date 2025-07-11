namespace med_consult_api.src.application;

public class CreateRequestExamDTO
{
    public required Guid ClinicalExamActId { get; set; }
    public required Guid AppointmentRequestId { get; set; }
       
}