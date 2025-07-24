namespace med_consult_api.src.application;

public class AppointmentConsultScheduleDTO : AppointmentDTO
{
    public required Guid AdministrativeId { get; set; }
    public required Guid AppointmentConsultRequestId { get; set; }
}