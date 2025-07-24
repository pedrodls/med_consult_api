namespace med_consult_api.src.application;

public class UpdateClinicalActDTO : UpdateDTO
{
    public Guid? ProfessionalId { get; set; }
    public Guid? SubsystemHealthId { get; set; }

}