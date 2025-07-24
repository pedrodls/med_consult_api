namespace med_consult_api.src.application;

public class AppointmentExamDoneDTO : AppointmentDTO
{
    public required Guid AdministrativeId { get; set; }
    public required Guid AppointmentExamScheduleId { get; set; }
}