
using med_consult_api.src.application;

namespace med_consult_api.src.infrastructure;

public class AppointmentExamDoneQuery : Query
{
    public Guid? AdministrativeId { get; set; }
    public Guid? AppointmentExamScheduleId { get; set; }
    public DateTime? Date { get; set; }

}
