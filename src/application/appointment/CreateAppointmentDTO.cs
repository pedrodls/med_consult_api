namespace med_consult_api.src.application;

public class CreateAppointmentDTO
{
    public required DateTime Date { get; set; }
    public required string Observations { get; set; }
}