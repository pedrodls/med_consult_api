namespace med_consult_api.src.domain;

public abstract class AppointmentModel : DomainModel
{
    public DateTime Date { get; set; }
    public string Observations { get; set; }

    protected AppointmentModel()
    {}
    public AppointmentModel(
        DateTime Date,
        string Observations
    )
        : base()
    {
        this.Date = Date;
        this.Observations = Observations;
    }

    public AppointmentModel(
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
        this.Date = Date;
        this.Observations = Observations;
    }


}