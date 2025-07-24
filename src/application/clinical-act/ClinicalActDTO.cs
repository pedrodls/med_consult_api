namespace med_consult_api.src.application;

public class ClinicalActDTO : Dto
{
    public Guid? ProfessionalId { get; set; } = new();
    public required Guid SubsystemHealthId { get; set; }

}