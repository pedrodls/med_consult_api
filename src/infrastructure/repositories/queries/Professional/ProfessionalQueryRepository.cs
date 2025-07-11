
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class ProfessionalQueryRepository : IQueryRepository<Professional>
{
    public IQueryable<Professional> GetWhereClause(Query? queryParams, IQueryable<Professional> queryModel)
    {
        ProfessionalQuery? ProfessionalQuery = queryParams as ProfessionalQuery;

        if (!string.IsNullOrWhiteSpace(ProfessionalQuery?.UserProfileId.ToString()))
            queryModel = queryModel.Where(r => r.UserProfileId.Equals(ProfessionalQuery.UserProfileId));

        if (!string.IsNullOrWhiteSpace(ProfessionalQuery?.SpecialityId.ToString()))
            queryModel = queryModel.Where(r => r.SpecialityId.Equals(ProfessionalQuery.SpecialityId));

        return queryModel;
    }
}