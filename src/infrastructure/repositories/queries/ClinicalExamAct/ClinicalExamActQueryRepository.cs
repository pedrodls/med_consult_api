
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class ClinicalExamActQueryRepository : IQueryRepository<ClinicalExamAct>
{
    public IQueryable<ClinicalExamAct> GetWhereClause(Query? queryParams, IQueryable<ClinicalExamAct> queryModel)
    {
        ClinicalExamActQuery? ExamQuery = queryParams as ClinicalExamActQuery;

        if (!string.IsNullOrWhiteSpace(ExamQuery?.ExamId.ToString()))
            queryModel = queryModel.Where(r => r.ExamId.Equals(ExamQuery.ExamId));

        if (!string.IsNullOrWhiteSpace(ExamQuery?.ProfessionalId.ToString()))
            queryModel = queryModel.Where(r => r.ProfessionalId.Equals(ExamQuery.ProfessionalId));

        if (!string.IsNullOrWhiteSpace(ExamQuery?.SubsystemHealthId.ToString()))
            queryModel = queryModel.Where(r => r.SubsystemHealthId.Equals(ExamQuery.SubsystemHealthId));

        return queryModel;
    }
}