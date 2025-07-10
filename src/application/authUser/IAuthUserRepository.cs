using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public interface IAuthUserRepository : IRepository<AuthUser>
{
    public Task<AuthUser?> FindOneByUserNameAsync(string username);

}