namespace med_consult_api.src.domain;

public class AppointmentScheduleRequest : AppointmentModel
{
    public UserProfile? UserProfile { get; set; }
    public Guid UserProfileId { get; set; }
    public DateTime? DoneAt { get; set; }

    private AppointmentScheduleRequest()
    {
        
    }
    public AppointmentScheduleRequest(
        Guid AppointmentRequestId,
        DateTime Date,
        string Observations,
        Guid UserProfileId,
        DateTime DoneAt
    )
        : base(AppointmentRequestId, Date, Observations)
    {
        this.DoneAt = DoneAt;
        this.UserProfileId = UserProfileId;
    }

    public AppointmentScheduleRequest(
        Guid AppointmentRequestId,
        DateTime Date,
        string Observations,
        DateTime DoneAt,
        Guid UserProfileId,
        Guid? id,
        bool? isActive,
        bool? isDeleted,
        DateTime? createdAt,
        DateTime? updatedAt,
        DateTime? deletedAt
       ) : base(AppointmentRequestId, Date, Observations, id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        this.DoneAt = DoneAt;
        this.UserProfileId = UserProfileId;
    }

    public void MarkAsDone()
    {
        DoneAt = DateTime.UtcNow;
        Deactivate();
        Touch();
    }

}