namespace med_consult_api.src.application;

public class AppointmentExamRequestDTO : Dto
{
    public List<CreateClinicalExamActDTO>? ClinicalExamActs { get; set; }
    public required Guid UserProfileId { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required string Observations { get; set; }
}