namespace med_consult_api.src.application;

public class CreateAppointmentConsultDoneDTO : CreateAppointmentDTO
{
    public required Guid AdministrativeId { get; set; }
    public required Guid AppointmentConsultScheduleId { get; set; }

}