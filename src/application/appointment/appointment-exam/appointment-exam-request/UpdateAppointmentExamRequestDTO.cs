
namespace med_consult_api.src.application;

public class UpdateAppointmentExamRequestDTO : UpdateDTO
{
    public List<ClinicalExamActDTO>? ClinicalExamActs { get; set; }
    public Guid? UserProfileId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Observations { get; set; }

}