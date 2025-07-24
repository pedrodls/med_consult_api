
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class AppointmentExamDoneQueryRepository : IQueryRepository<AppointmentExamDone>
{
    public IQueryable<AppointmentExamDone> GetWhereClause(Query? queryParams, IQueryable<AppointmentExamDone> queryModel)
    {
        AppointmentExamDoneQuery? ExamQuery = queryParams as AppointmentExamDoneQuery;

        if (!string.IsNullOrWhiteSpace(ExamQuery?.AppointmentExamScheduleId.ToString()))
            queryModel = queryModel.Where(r => r.AppointmentExamScheduleId.Equals(ExamQuery.AppointmentExamScheduleId));

        if (!string.IsNullOrWhiteSpace(ExamQuery?.Date.ToString()))
            queryModel = queryModel.Where(r => r.Date.Equals(ExamQuery.Date));

        if (!string.IsNullOrWhiteSpace(ExamQuery?.AdministrativeId.ToString()))
            queryModel = queryModel.Where(r => r.AdministrativeId.Equals(ExamQuery.AdministrativeId));

        return queryModel;
    }
}