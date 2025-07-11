namespace med_consult_api.src.application;

public class UpdateRequestConsultDTO : UpdateDTO
{
    public Guid? ClinicalConsultActId { get; set; }

    public Guid? AppointmentRequestId { get; set; }

}