
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class AppointmentConsultDoneQueryRepository : IQueryRepository<AppointmentConsultDone>
{
    public IQueryable<AppointmentConsultDone> GetWhereClause(Query? queryParams, IQueryable<AppointmentConsultDone> queryModel)
    {
        AppointmentConsultDoneQuery? ConsultQuery = queryParams as AppointmentConsultDoneQuery;

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.AppointmentConsultScheduleId.ToString()))
            queryModel = queryModel.Where(r => r.AppointmentConsultScheduleId.Equals(ConsultQuery.AppointmentConsultScheduleId));

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.Date.ToString()))
            queryModel = queryModel.Where(r => r.Date.Equals(ConsultQuery.Date));

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.AdministrativeId.ToString()))
            queryModel = queryModel.Where(r => r.AdministrativeId.Equals(ConsultQuery.AdministrativeId));

        return queryModel;
    }
}