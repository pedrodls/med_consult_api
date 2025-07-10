using System.Security.Claims;
using med_consult_api.src.application;
using med_consult_api.src.domain;
using med_consult_api.src.presentation.services;

namespace med_consult_api.src.presentation;

public class AuthService : IAuthService
{
    private readonly IAuthUserRepository authUserRepo;
    private readonly IJwtService jwtService;

    public AuthService(IAuthUserRepository authUserRepo, IJwtService jwtService)
    {
        this.authUserRepo = authUserRepo;
        this.jwtService = jwtService;

    }

    public async Task<TokenDTO> LoginAsync(LoginDTO loginDTO)
    {
        var user = await authUserRepo.FindOneByUserNameAsync(loginDTO.UserName);

        if (user == null) // ⚠️ Em produção, usa hash!
            throw new UnauthorizedAccessException("Credenciais inválidas");

        return new TokenDTO
        {
            Token = jwtService.GenerateToken([
                new Claim("userId", user.Id.ToString()),
                new Claim("userProfileId", user.UserProfileId.ToString()),
                new Claim("userName", user.UserName),
                new Claim("role", user.Role.Name)
            ])
        };
    }
}
