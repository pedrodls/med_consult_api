
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class AppointmentConsultScheduleQueryRepository : IQueryRepository<AppointmentConsultSchedule>
{
    public IQueryable<AppointmentConsultSchedule> GetWhereClause(Query? queryParams, IQueryable<AppointmentConsultSchedule> queryModel)
    {
        AppointmentConsultScheduleQuery? ConsultQuery = queryParams as AppointmentConsultScheduleQuery;

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.AppointmentConsultRequestId.ToString()))
            queryModel = queryModel.Where(r => r.AppointmentConsultRequestId.Equals(ConsultQuery.AppointmentConsultRequestId));

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.Date.ToString()))
            queryModel = queryModel.Where(r => r.Date.Equals(ConsultQuery.Date));

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.AdministrativeId.ToString()))
            queryModel = queryModel.Where(r => r.AdministrativeId.Equals(ConsultQuery.AdministrativeId));

        return queryModel;
    }
}