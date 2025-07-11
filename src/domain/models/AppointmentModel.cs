namespace med_consult_api.src.domain;

public abstract class AppointmentModel : DomainModel
{
    public AppointmentRequest? AppointmentRequest { get; set; }
    public Guid AppointmentRequestId { get; set; }
    public DateTime Date { get; set; }
    public string Observations { get; set; }

    protected AppointmentModel()
    {}
    public AppointmentModel(
        Guid AppointmentRequestId,
        DateTime Date,
        string Observations
    )
        : base()
    {
        this.AppointmentRequestId = AppointmentRequestId;
        this.Date = Date;
        this.Observations = Observations;
    }

    public AppointmentModel(
        Guid AppointmentRequestId,
        DateTime Date,
        string Observations,
        Guid? id,
        bool? isActive,
        bool? isDeleted,
        DateTime? createdAt,
        DateTime? updatedAt,
        DateTime? deletedAt
       ) : base(id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        this.AppointmentRequestId = AppointmentRequestId;
        this.Date = Date;
        this.Observations = Observations;
    }


}