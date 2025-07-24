
namespace med_consult_api.src.application;

public class UpdateAppointmentConsultDoneDTO : UpdateAppointmentDTO
{
    public  Guid? AdministrativeId { get; set; }
    public  Guid? AppointmentConsultScheduleId { get; set; }

}