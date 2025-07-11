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

        if (typeof(T) == typeof(SubsystemHealth) && queryModel is IQueryable<SubsystemHealth> subsystemHeallthQueryModel)
            queryResult = new SubsystemHealthQueryRepository().GetWhereClause(queryParams, subsystemHeallthQueryModel).Cast<T>();

        if (typeof(T) == typeof(Role) && queryModel is IQueryable<Role> roleQueryModel)
            queryResult = new RoleQueryRepository().GetWhereClause(queryParams, roleQueryModel).Cast<T>();

        if (typeof(T) == typeof(UserProfile) && queryModel is IQueryable<UserProfile> userProfileQueryModel)
            queryResult = new UserProfileQueryRepository().GetWhereClause(queryParams, userProfileQueryModel).Cast<T>();

        return queryResult;
    }

}
