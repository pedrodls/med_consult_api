namespace med_consult_api.src.domain;

public class ClinicalConsultAct : ClinicalActModel
{
    public Consult? Consult { get; set; }
    public Guid? ConsultId { get; set; }

    private ClinicalConsultAct()
    {

    }
    public ClinicalConsultAct(Guid ConsultId, Guid ProfessionalId, Guid SubsystemHealthId)
        : base(ProfessionalId, SubsystemHealthId)
    {
        this.ConsultId = ConsultId;
    }

    public ClinicalConsultAct(
        Guid consultId, Guid professionalId, Guid subsystemHealthId,
        Guid? id,
           bool? isActive,
           bool? isDeleted,
           DateTime? createdAt,
           DateTime? updatedAt,
           DateTime? deletedAt
       ) : base(professionalId, subsystemHealthId, id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        ConsultId = consultId;
    }

}