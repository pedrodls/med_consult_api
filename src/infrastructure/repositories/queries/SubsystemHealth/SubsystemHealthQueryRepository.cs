
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class SubsystemHealthQueryRepository : IQueryRepository<SubsystemHealth>
{
    public IQueryable<SubsystemHealth> GetWhereClause(Query? queryParams, IQueryable<SubsystemHealth> queryModel)
    {
        SubsystemHealthQuery? SubsystemHealthQuery = queryParams as SubsystemHealthQuery;

        if (!string.IsNullOrWhiteSpace(SubsystemHealthQuery?.Name))
            queryModel = queryModel.Where(r => r.Name.Contains(SubsystemHealthQuery.Name));

        return queryModel;
    }
}