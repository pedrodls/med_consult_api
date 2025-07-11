namespace med_consult_api.src.application;

public class RequestConsultDTO : Dto
{
    public required Guid ClinicalConsultActId { get; set; }
    public required Guid AppointmentRequestId { get; set; }

}