using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class UserProfileQueryRepository : IQueryRepository<UserProfile>
{
    public IQueryable<UserProfile> GetWhereClause(Query? queryParams, IQueryable<UserProfile> queryModel)
    {
        var query = queryModel;
        var userProfileQuery = queryParams as UserProfileQuery;

        if (userProfileQuery == null)
            return query;

        if (!string.IsNullOrWhiteSpace(userProfileQuery.FirstName))
        {
            query = query.Where(p => p.FullName.FirstName.Contains(userProfileQuery.FirstName));
        }

        if (!string.IsNullOrWhiteSpace(userProfileQuery.LastName))
        {
            query = query.Where(p => p.FullName.LastName.Contains(userProfileQuery.LastName));
        }

        if (userProfileQuery.Birthdate != default)
        {
            query = query.Where(p => p.Birthdate.Date.Date == userProfileQuery.Birthdate.Date);
        }

        if (!string.IsNullOrWhiteSpace(userProfileQuery.Gender))
        {
            query = query.Where(p => p.Gender.value.ToString().ToLower() == userProfileQuery.Gender.ToLower());
        }

        if (!string.IsNullOrWhiteSpace(userProfileQuery.Telephone))
        {
            query = query.Where(p => p.Telephone.Value.Contains(userProfileQuery.Telephone));
        }

        if (!string.IsNullOrWhiteSpace(userProfileQuery.Email))
        {
            query = query.Where(p => p.Email.Value.Contains(userProfileQuery.Email));
        }

        if (!string.IsNullOrWhiteSpace(userProfileQuery.Street))
        {
            query = query.Where(p => p.Address.Street.Contains(userProfileQuery.Street));
        }

        if (!string.IsNullOrWhiteSpace(userProfileQuery.City))
        {
            query = query.Where(p => p.Address.City.Contains(userProfileQuery.City));
        }

        if (!string.IsNullOrWhiteSpace(userProfileQuery.State))
        {
            query = query.Where(p => p.Address.State.Contains(userProfileQuery.State));
        }

       
        return query;
    }
}
