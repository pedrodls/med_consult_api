using med_consult_api.src.application;

namespace med_consult_api.src.infrastructure;

public class RequestConsultQuery : Query
{
    public Guid? ClinicalConsultActId { get; set; }
    public Guid? AppointmentRequestId { get; set; }

}
