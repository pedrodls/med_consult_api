

using Microsoft.EntityFrameworkCore;
using med_consult_api.src.domain;
using med_consult_api.src.infrastructure;
using med_consult_api.src.application;

public class AuthUserRepository : Repository<AuthUser>, IAuthUserRepository
{
    public AuthUserRepository(DatabaseContext context) : base(context)
    { }

    public async Task<AuthUser?> FindOneByUserNameAsync(string username)
    {
        return await dbSet
            .Include(u => u.Role)
            .Include(u => u.UserProfile)
            .FirstOrDefaultAsync(u => u.UserName == username);
    }

}