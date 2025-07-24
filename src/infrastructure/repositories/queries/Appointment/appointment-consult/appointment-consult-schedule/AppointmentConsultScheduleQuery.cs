
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class AppointmentConsultScheduleQuery : Query
{
    public Guid? AdministrativeId { get; set; }
    public Guid? AppointmentConsultRequestId { get; set; }
    public DateTime? Date { get; set; }

}
