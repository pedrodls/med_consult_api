
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class ExamCategoryQueryRepository : IQueryRepository<ExamCategory>
{
    public IQueryable<ExamCategory> GetWhereClause(Query? queryParams, IQueryable<ExamCategory> queryModel)
    {
        ExamCategoryQuery? ExamCategoryQuery = queryParams as ExamCategoryQuery;

        if (!string.IsNullOrWhiteSpace(ExamCategoryQuery?.Name))
            queryModel = queryModel.Where(r => r.Name.Contains(ExamCategoryQuery.Name));

        if (!string.IsNullOrWhiteSpace(ExamCategoryQuery?.Description))
            queryModel = queryModel.Where(r => r.Description.Contains(ExamCategoryQuery.Description));

        return queryModel;
    }
}