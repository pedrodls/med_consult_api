namespace med_consult_api.src.domain;

public class RequestExam : RequestModel
{
    public ClinicalExamAct? ClinicalExamAct { get; set; }
    public Guid ClinicalExamActId { get; set; }

    public RequestExam(Guid ClinicalExamActId, Guid AppointmentRequestId)
        : base(AppointmentRequestId)
    {
        this.ClinicalExamActId = ClinicalExamActId;
    }

    public RequestExam(
        Guid ClinicalExamActId, Guid AppointmentRequestId,
        Guid? id,
           bool? isActive,
           bool? isDeleted,
           DateTime? createdAt,
           DateTime? updatedAt,
           DateTime? deletedAt
       ) : base(AppointmentRequestId, id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        this.ClinicalExamActId = ClinicalExamActId;
    }

}