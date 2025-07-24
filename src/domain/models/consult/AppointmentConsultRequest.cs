namespace med_consult_api.src.domain;

public class AppointmentConsultRequest : DomainModel
{
    public List<ClinicalConsultAct> ClinicalConsultActs { get; set; } = new();
    public UserProfile? UserProfile { get; set; }
    public Guid UserProfileId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Observations { get; set; }

    public AppointmentConsultRequest(
        Guid UserProfileId,
        DateTime StartDate,
        DateTime EndDate,
        string Observations
    )
        : base()
    {
        this.UserProfileId = UserProfileId;
        this.StartDate = StartDate;
        this.EndDate = EndDate;
        this.Observations = Observations;
    }

    public AppointmentConsultRequest(
        Guid UserProfileId,
        DateTime StartDate,
        DateTime EndDate,
        string Observations,
        Guid? id,
           bool? isActive,
           bool? isDeleted,
           DateTime? createdAt,
           DateTime? updatedAt,
           DateTime? deletedAt
       ) : base(id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        this.UserProfileId = UserProfileId;
        this.StartDate = StartDate;
        this.EndDate = EndDate;
        this.Observations = Observations;
    }

}