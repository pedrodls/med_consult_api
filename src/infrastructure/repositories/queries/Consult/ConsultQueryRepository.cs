
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class ConsultQueryRepository : IQueryRepository<Consult>
{
    public IQueryable<Consult> GetWhereClause(Query? queryParams, IQueryable<Consult> queryModel)
    {
        ConsultQuery? ConsultQuery = queryParams as ConsultQuery;

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.Name))
            queryModel = queryModel.Where(r => r.Name.Contains(ConsultQuery.Name));

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.Description))
            queryModel = queryModel.Where(r => r.Description.Contains(ConsultQuery.Description));

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.SpecialityId.ToString()))
            queryModel = queryModel.Where(r => r.SpecialityId.Equals(ConsultQuery.SpecialityId));

        return queryModel;
    }
}