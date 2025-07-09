
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class QueryPageParamsRepository<T> : IQueryRepository<T>
where T : DomainModel
{
    public IQueryable<T> GetWhereClause(Query? queryParams, IQueryable<T> queryModel)
    {

        if (queryParams?.IsActive != null)
            queryModel = queryModel.Where(r => r.IsActive == queryParams.IsActive);

        if (queryParams?.IsDeleted != null)
            queryModel = queryModel.Where(r => r.IsDeleted == queryParams.IsDeleted);

        if (queryParams?.CreatedAt != null)
            queryModel = queryModel.Where(r => r.CreatedAt == queryParams.CreatedAt);

        if (queryParams?.UpdatedAt != null)
            queryModel = queryModel.Where(r => r.UpdatedAt == queryParams.UpdatedAt);

        if (queryParams?.DeletedAt != null)
            queryModel = queryModel.Where(r => r.DeletedAt == queryParams.DeletedAt);

        if (queryParams?.Order?.ToUpper() == "DESC")
            queryModel = queryModel.OrderByDescending(r => r.CreatedAt);
        else
            queryModel = queryModel.OrderBy(r => r.CreatedAt);

        return queryModel;
    }


}