
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class AppointmentConsultRequestQueryRepository : IQueryRepository<AppointmentConsultRequest>
{
    public IQueryable<AppointmentConsultRequest> GetWhereClause(Query? queryParams, IQueryable<AppointmentConsultRequest> queryModel)
    {
        AppointmentConsultRequestQuery? ConsultQuery = queryParams as AppointmentConsultRequestQuery;

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.UserProfileId.ToString()))
            queryModel = queryModel.Where(r => r.UserProfileId.Equals(ConsultQuery.UserProfileId));

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.StartDate.ToString()))
            queryModel = queryModel.Where(r => r.StartDate.Equals(ConsultQuery.StartDate));

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.EndDate.ToString()))
            queryModel = queryModel.Where(r => r.EndDate.Equals(ConsultQuery.EndDate));

        return queryModel;
    }
}