namespace med_consult_api.src.domain;

public class AppointmentConsultDone : AppointmentModel
{
    public UserProfile? Administrative { get; set; }
    public Guid AdministrativeId { get; set; }
    public AppointmentConsultSchedule? AppointmentConsultSchedule { get; set; }
    public Guid AppointmentConsultScheduleId { get; set; }

    private AppointmentConsultDone()
    {

    }
    public AppointmentConsultDone(
        Guid AppointmentConsultScheduleId,
        DateTime Date,
        string Observations,
        Guid AdministrativeId
    )
        : base(Date, Observations)
    {
        this.AdministrativeId = AdministrativeId;
        this.AppointmentConsultScheduleId = AppointmentConsultScheduleId;
    }

    public AppointmentConsultDone(
        Guid AppointmentConsultScheduleId,
        DateTime Date,
        string Observations,
        Guid AdministrativeId,
        Guid? id,
        bool? isActive,
        bool? isDeleted,
        DateTime? createdAt,
        DateTime? updatedAt,
        DateTime? deletedAt
       ) : base(Date, Observations, id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        this.AdministrativeId = AdministrativeId;
        this.AppointmentConsultScheduleId = AppointmentConsultScheduleId;
    }
}