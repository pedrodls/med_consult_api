namespace med_consult_api.src.domain;

public abstract class RequestModel : DomainModel
{
    public AppointmentRequest? AppointmentRequest { get; set; }
    public Guid AppointmentRequestId { get; set; }

    public RequestModel(Guid AppointmentRequestId)
        : base()
    {
        this.AppointmentRequestId = AppointmentRequestId;
    }

    public RequestModel(
        Guid AppointmentRequestId,
        Guid? id,
           bool? isActive,
           bool? isDeleted,
           DateTime? createdAt,
           DateTime? updatedAt,
           DateTime? deletedAt
       ) : base(id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        this.AppointmentRequestId = AppointmentRequestId;
    }

}