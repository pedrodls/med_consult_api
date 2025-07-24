namespace med_consult_api.src.application;

public class CreateAppointmentExamDoneDTO : CreateAppointmentDTO
{
    public required Guid AdministrativeId { get; set; }
    public required Guid AppointmentExamScheduleId { get; set; }

}