namespace med_consult_api.src.application;

public class UpdateClinicalConsultActDTO : UpdateClinicalActDTO
{
    public Guid? ConsultId { get; set; }
}