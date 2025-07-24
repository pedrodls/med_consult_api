namespace med_consult_api.src.application;

public class UpdateAppointmentDTO : UpdateDTO
{
    public DateTime? Date { get; set; }
    public string? Observations { get; set; }

}