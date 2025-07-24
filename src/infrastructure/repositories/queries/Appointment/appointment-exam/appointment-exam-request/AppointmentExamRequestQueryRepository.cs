
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class AppointmentExamRequestQueryRepository : IQueryRepository<AppointmentExamRequest>
{
    public IQueryable<AppointmentExamRequest> GetWhereClause(Query? queryParams, IQueryable<AppointmentExamRequest> queryModel)
    {
        AppointmentExamRequestQuery? ExamQuery = queryParams as AppointmentExamRequestQuery;

        if (!string.IsNullOrWhiteSpace(ExamQuery?.UserProfileId.ToString()))
            queryModel = queryModel.Where(r => r.UserProfileId.Equals(ExamQuery.UserProfileId));

        if (!string.IsNullOrWhiteSpace(ExamQuery?.StartDate.ToString()))
            queryModel = queryModel.Where(r => r.StartDate.Equals(ExamQuery.StartDate));

        if (!string.IsNullOrWhiteSpace(ExamQuery?.EndDate.ToString()))
            queryModel = queryModel.Where(r => r.EndDate.Equals(ExamQuery.EndDate));

        return queryModel;
    }
}