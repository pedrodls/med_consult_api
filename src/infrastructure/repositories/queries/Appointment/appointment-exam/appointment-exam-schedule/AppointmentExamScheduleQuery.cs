
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class AppointmentExamScheduleQuery : Query
{
    public Guid? AdministrativeId { get; set; }
    public Guid? AppointmentExamRequestId { get; set; }
    public DateTime? Date { get; set; }

}
