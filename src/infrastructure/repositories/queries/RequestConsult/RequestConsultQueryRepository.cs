
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class RequestConsultQueryRepository : IQueryRepository<RequestConsult>
{
    public IQueryable<RequestConsult> GetWhereClause(Query? queryParams, IQueryable<RequestConsult> queryModel)
    {
        RequestConsultQuery? ConsultQuery = queryParams as RequestConsultQuery;

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.ClinicalConsultActId.ToString()))
            queryModel = queryModel.Where(r => r.ClinicalConsultActId.Equals(ConsultQuery.ClinicalConsultActId));

         if (!string.IsNullOrWhiteSpace(ConsultQuery?.AppointmentRequestId.ToString()))
            queryModel = queryModel.Where(r => r.AppointmentRequestId.Equals(ConsultQuery.AppointmentRequestId));

        return queryModel;
    }
}