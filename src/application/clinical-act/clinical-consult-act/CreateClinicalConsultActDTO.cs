namespace med_consult_api.src.application;

public class CreateClinicalConsultActDTO : CreateClinicalActDTO
{
    public required Guid ConsultId { get; set; }
}