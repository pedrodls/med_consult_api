using med_consult_api.src.application;
using med_consult_api.src.domain;
namespace med_consult_api.src.infrastructure;

public class QueryActionRepository<T>
 where T : DomainModel
{
    private readonly IQueryable<T> queryModel;
    private readonly Query? queryParams;

    public QueryActionRepository(IQueryable<T> queryModel, Query? queryParams)
    {
        this.queryModel = queryModel;
        this.queryParams = queryParams;
    }

    public IQueryable<T> GetWhereClause()
    {
        var queryResult = queryModel;

        if (typeof(T) == typeof(Role) && queryModel is IQueryable<Role> roleQueryModel)
            queryResult = new RoleQueryRepository().GetWhereClause(queryParams, roleQueryModel).Cast<T>();

        return queryResult;
    }

}
