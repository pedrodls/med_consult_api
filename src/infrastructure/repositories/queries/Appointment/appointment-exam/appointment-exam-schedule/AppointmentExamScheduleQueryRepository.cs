
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class AppointmentExamScheduleQueryRepository : IQueryRepository<AppointmentExamSchedule>
{
    public IQueryable<AppointmentExamSchedule> GetWhereClause(Query? queryParams, IQueryable<AppointmentExamSchedule> queryModel)
    {
        AppointmentExamScheduleQuery? ExamQuery = queryParams as AppointmentExamScheduleQuery;

        if (!string.IsNullOrWhiteSpace(ExamQuery?.AppointmentExamRequestId.ToString()))
            queryModel = queryModel.Where(r => r.AppointmentExamRequestId.Equals(ExamQuery.AppointmentExamRequestId));

        if (!string.IsNullOrWhiteSpace(ExamQuery?.Date.ToString()))
            queryModel = queryModel.Where(r => r.Date.Equals(ExamQuery.Date));

        if (!string.IsNullOrWhiteSpace(ExamQuery?.AdministrativeId.ToString()))
            queryModel = queryModel.Where(r => r.AdministrativeId.Equals(ExamQuery.AdministrativeId));

        return queryModel;
    }
}