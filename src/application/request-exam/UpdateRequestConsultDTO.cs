namespace med_consult_api.src.application;

public class UpdateRequestExamDTO : UpdateDTO
{
    public Guid? ClinicalExamActId { get; set; }

    public Guid? AppointmentRequestId { get; set; }

}