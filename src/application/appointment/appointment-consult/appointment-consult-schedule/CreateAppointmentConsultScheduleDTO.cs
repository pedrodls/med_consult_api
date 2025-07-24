namespace med_consult_api.src.application;

public class CreateAppointmentConsultScheduleDTO : CreateAppointmentDTO
{
    public required Guid AdministrativeId { get; set; }
    public required Guid AppointmentConsultRequestId { get; set; }

}