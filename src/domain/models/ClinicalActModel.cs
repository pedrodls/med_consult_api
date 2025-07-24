namespace med_consult_api.src.domain;

public abstract class ClinicalActModel : DomainModel
{
    public Professional? Professional { get; set; }
    public SubsystemHealth? SubsystemHealth { get; set; }
    public Guid? ProfessionalId { get; set; }
    public Guid SubsystemHealthId { get; set; }

protected ClinicalActModel() {}
    public ClinicalActModel(Guid? professionalId, Guid subsystemHealthId)
        : base()
    {
        ProfessionalId = professionalId;
        SubsystemHealthId = subsystemHealthId;
    }

    public ClinicalActModel(
        Guid? ProfessionalId, Guid SubsystemHealthId,
        Guid? id,
        bool? isActive,
        bool? isDeleted,
        DateTime? createdAt,
        DateTime? updatedAt,
        DateTime? deletedAt
       ) : base(id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {

        this.ProfessionalId = ProfessionalId;
        this.SubsystemHealthId = SubsystemHealthId;
    }

}