
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class SpecialityQueryRepository : IQueryRepository<Speciality>
{
    public IQueryable<Speciality> GetWhereClause(Query? queryParams, IQueryable<Speciality> queryModel)
    {
        SpecialityQuery? SpecialityQuery = queryParams as SpecialityQuery;

        if (!string.IsNullOrWhiteSpace(SpecialityQuery?.Name))
            queryModel = queryModel.Where(r => r.Name.Contains(SpecialityQuery.Name));

        if (!string.IsNullOrWhiteSpace(SpecialityQuery?.Description))
            queryModel = queryModel.Where(r => r.Description.Contains(SpecialityQuery.Description));

        return queryModel;
    }
}