namespace med_consult_api.src.domain;

public class ClinicalExamAct : ClinicalActModel
{
    public Exam? Exam { get; set; }
    public Guid ExamId { get; set; }

    private ClinicalExamAct() { }
    public ClinicalExamAct(Guid ExamId, Guid? ProfessionalId, Guid SubsystemHealthId)
        : base(ProfessionalId, SubsystemHealthId)
    {
        this.ExamId = ExamId;
    }

    public ClinicalExamAct(
        Guid examId, Guid? professionalId, Guid subsystemHealthId,
        Guid? id,
           bool? isActive,
           bool? isDeleted,
           DateTime? createdAt,
           DateTime? updatedAt,
           DateTime? deletedAt
       ) : base(professionalId, subsystemHealthId, id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        ExamId = examId;
    }

}