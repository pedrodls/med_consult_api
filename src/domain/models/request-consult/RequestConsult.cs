namespace med_consult_api.src.domain;

public class RequestConsult : RequestModel
{
    public ClinicalConsultAct? ClinicalConsultAct { get; set; }
    public Guid ClinicalConsultActId { get; set; }

    public RequestConsult(Guid ClinicalConsultActId, Guid AppointmentRequestId)
        : base(AppointmentRequestId)
    {
        this.ClinicalConsultActId = ClinicalConsultActId;
    }

    public RequestConsult(
        Guid ClinicalConsultActId, Guid AppointmentRequestId,
        Guid? id,
           bool? isActive,
           bool? isDeleted,
           DateTime? createdAt,
           DateTime? updatedAt,
           DateTime? deletedAt
       ) : base(AppointmentRequestId, id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        this.ClinicalConsultActId = ClinicalConsultActId;
    }

}