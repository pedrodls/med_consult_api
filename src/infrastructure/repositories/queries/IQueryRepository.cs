using med_consult_api.src.application;

namespace med_consult_api.src.infrastructure;

public interface IQueryRepository<T>
{
    IQueryable<T> GetWhereClause(Query queryParams, IQueryable<T> queryModel);
}
