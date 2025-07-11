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

        if (typeof(T) == typeof(ExamCategory) && queryModel is IQueryable<ExamCategory> examCategoryQueryModel)
            queryResult = new ExamCategoryQueryRepository().GetWhereClause(queryParams, examCategoryQueryModel).Cast<T>();

        if (typeof(T) == typeof(Exam) && queryModel is IQueryable<Exam> examQueryModel)
            queryResult = new ExamQueryRepository().GetWhereClause(queryParams, examQueryModel).Cast<T>();


        if (typeof(T) == typeof(Consult) && queryModel is IQueryable<Consult> consultQueryModel)
            queryResult = new ConsultQueryRepository().GetWhereClause(queryParams, consultQueryModel).Cast<T>();

        if (typeof(T) == typeof(Speciality) && queryModel is IQueryable<Speciality> specialityQueryModel)
            queryResult = new SpecialityQueryRepository().GetWhereClause(queryParams, specialityQueryModel).Cast<T>();

        if (typeof(T) == typeof(UserProfile) && queryModel is IQueryable<UserProfile> userProfileQueryModel)
            queryResult = new UserProfileQueryRepository().GetWhereClause(queryParams, userProfileQueryModel).Cast<T>();

        return queryResult;
    }

}
