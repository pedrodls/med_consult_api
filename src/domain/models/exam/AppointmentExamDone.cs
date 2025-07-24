namespace med_consult_api.src.domain;

public class AppointmentExamDone : AppointmentModel
{
    public UserProfile? Administrative { get; set; }
    public Guid AdministrativeId { get; set; }
    public AppointmentExamSchedule? AppointmentExamSchedule { get; set; }
    public Guid AppointmentExamScheduleId { get; set; }

    private AppointmentExamDone()
    {

    }
    public AppointmentExamDone(
        Guid AppointmentExamScheduleId,
        DateTime Date,
        string Observations,
        Guid AdministrativeId
    )
        : base(Date, Observations)
    {
        this.AdministrativeId = AdministrativeId;
        this.AppointmentExamScheduleId = AppointmentExamScheduleId;
    }

    public AppointmentExamDone(
        Guid AppointmentExamScheduleId,
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
        this.AppointmentExamScheduleId = AppointmentExamScheduleId;
    }
}