using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class AuthUserQueryRepository : IQueryRepository<AuthUser>
{
    public IQueryable<AuthUser> GetWhereClause(Query? queryParams, IQueryable<AuthUser> queryModel)
    {
        var query = queryModel;
        var authUserQuery = queryParams as AuthUserQuery;

        if (!string.IsNullOrWhiteSpace(authUserQuery?.UserName))
            query = query.Where(p => p.UserName.Contains(authUserQuery.UserName));

        if (!string.IsNullOrWhiteSpace(authUserQuery?.Password))
            query = query.Where(p => p.Password.Value.Contains(authUserQuery.Password));

        if (!string.IsNullOrWhiteSpace(authUserQuery?.RoleId.ToString()))
            query = query.Where(p => p.RoleId == authUserQuery.RoleId);

        return query;
    }
}
