using med_consult_api.src.application;

namespace med_consult_api.src.infrastructure;

public class RequestExamQuery : Query
{
    public Guid? ClinicalExamActId { get; set; }
    public Guid? AppointmentRequestId { get; set; }

}
