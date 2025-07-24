namespace med_consult_api.src.domain;

public class AppointmentExamSchedule : AppointmentModel
{
    public UserProfile? Administrative { get; set; }
    public Guid AdministrativeId { get; set; }
    public AppointmentExamRequest? AppointmentExamRequest { get; set; }
    public Guid AppointmentExamRequestId { get; set; }

    private AppointmentExamSchedule()
    {

    }
    public AppointmentExamSchedule(
        Guid AppointmentExamRequestId,
        DateTime Date,
        string Observations,
        Guid AdministrativeId
    )
        : base(Date, Observations)
    {
        this.AdministrativeId = AdministrativeId;
        this.AppointmentExamRequestId = AppointmentExamRequestId;
    }

    public AppointmentExamSchedule(
        Guid AppointmentExamRequestId,
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
        this.AppointmentExamRequestId = AppointmentExamRequestId;
    }
}