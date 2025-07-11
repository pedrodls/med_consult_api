
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class ExamQueryRepository : IQueryRepository<Exam>
{
    public IQueryable<Exam> GetWhereClause(Query? queryParams, IQueryable<Exam> queryModel)
    {
        ExamQuery? ExamQuery = queryParams as ExamQuery;

        if (!string.IsNullOrWhiteSpace(ExamQuery?.Name))
            queryModel = queryModel.Where(r => r.Name.Contains(ExamQuery.Name));

        if (!string.IsNullOrWhiteSpace(ExamQuery?.Description))
            queryModel = queryModel.Where(r => r.Description.Contains(ExamQuery.Description));

        if (!string.IsNullOrWhiteSpace(ExamQuery?.ExamCategoryId.ToString()))
            queryModel = queryModel.Where(r => r.ExamCategoryId.Equals(ExamQuery.ExamCategoryId));

        if (!string.IsNullOrWhiteSpace(ExamQuery?.SpecialityId.ToString()))
            queryModel = queryModel.Where(r => r.SpecialityId.Equals(ExamQuery.SpecialityId));
            
        return queryModel;
    }
}