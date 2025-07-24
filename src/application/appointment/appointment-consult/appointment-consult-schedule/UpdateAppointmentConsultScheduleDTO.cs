
namespace med_consult_api.src.application;

public class UpdateAppointmentConsultScheduleDTO : UpdateAppointmentDTO
{
    public  Guid? AdministrativeId { get; set; }
    public  Guid? AppointmentConsultRequestId { get; set; }

}