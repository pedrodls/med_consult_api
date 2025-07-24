namespace med_consult_api.src.application;

public class AppointmentDTO : Dto
{
    public required DateTime Date { get; set; }
    public required string Observations { get; set; }
}