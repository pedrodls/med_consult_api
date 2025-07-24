
using med_consult_api.src.application;

namespace med_consult_api.src.infrastructure;

public class AppointmentConsultDoneQuery : Query
{
    public Guid? AdministrativeId { get; set; }
    public Guid? AppointmentConsultScheduleId { get; set; }
    public DateTime? Date { get; set; }

}
