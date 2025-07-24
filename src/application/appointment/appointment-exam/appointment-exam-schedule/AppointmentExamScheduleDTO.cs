namespace med_consult_api.src.application;

public class AppointmentExamScheduleDTO : AppointmentDTO
{
    public required Guid AdministrativeId { get; set; }
    public required Guid AppointmentExamRequestId { get; set; }
}