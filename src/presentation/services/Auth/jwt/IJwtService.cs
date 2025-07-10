using System.Security.Claims;

namespace med_consult_api.src.presentation.services;

public interface IJwtService
{
    string GenerateToken(Claim[] claims);
}
