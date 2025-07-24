
namespace med_consult_api.src.application;

public class UpdateAppointmentExamDoneDTO : UpdateAppointmentDTO
{
    public  Guid? AdministrativeId { get; set; }
    public  Guid? AppointmentExamScheduleId { get; set; }

}