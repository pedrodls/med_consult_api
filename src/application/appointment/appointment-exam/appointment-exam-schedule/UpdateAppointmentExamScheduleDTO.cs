
namespace med_consult_api.src.application;

public class UpdateAppointmentExamScheduleDTO : UpdateAppointmentDTO
{
    public  Guid? AdministrativeId { get; set; }
    public  Guid? AppointmentExamRequestId { get; set; }

}