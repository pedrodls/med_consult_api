namespace med_consult_api.src.application;

public class CreateClinicalActDTO
{
    public Guid? ProfessionalId { get; set; }
    public required Guid SubsystemHealthId { get; set; }
}