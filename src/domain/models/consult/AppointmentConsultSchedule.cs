namespace med_consult_api.src.domain;

public class AppointmentConsultSchedule : AppointmentModel
{
    public UserProfile? Administrative { get; set; }
    public Guid AdministrativeId { get; set; }
    public AppointmentConsultRequest? AppointmentConsultRequest { get; set; }
    public Guid AppointmentConsultRequestId { get; set; }

    private AppointmentConsultSchedule()
    {

    }
    public AppointmentConsultSchedule(
        Guid AppointmentConsultRequestId,
        DateTime Date,
        string Observations,
        Guid AdministrativeId
    )
        : base(Date, Observations)
    {
        this.AdministrativeId = AdministrativeId;
        this.AppointmentConsultRequestId = AppointmentConsultRequestId;
    }

    public AppointmentConsultSchedule(
        Guid AppointmentConsultRequestId,
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
        this.AppointmentConsultRequestId = AppointmentConsultRequestId;
    }
}