
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class RoleQueryRepository : IQueryRepository<Role>
{
    public IQueryable<Role> GetWhereClause(Query? queryParams, IQueryable<Role> queryModel)
    {
        RoleQuery? roleQuery = queryParams as RoleQuery;

        if (!string.IsNullOrWhiteSpace(roleQuery?.Name))
            queryModel = queryModel.Where(r => r.Name.Contains(roleQuery.Name));

        if (!string.IsNullOrWhiteSpace(roleQuery?.Description))
            queryModel = queryModel.Where(r => r.Description.Contains(roleQuery.Description));

        return queryModel;
    }
}