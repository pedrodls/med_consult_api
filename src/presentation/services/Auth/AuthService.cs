using System.Security.Claims;
using med_consult_api.src.application;
using med_consult_api.src.domain;
using med_consult_api.src.infrastructure;
using med_consult_api.src.presentation.services;

namespace med_consult_api.src.presentation;

public class AuthService : IAuthService
{
    private readonly IAuthUserRepository authUserRepo;
    private readonly IJwtService jwtService;
    private readonly IBcryptService bcryptService;

    public AuthService(IAuthUserRepository authUserRepo, IJwtService jwtService, IBcryptService bcryptService)
    {
        this.authUserRepo = authUserRepo;
        this.jwtService = jwtService;
        this.bcryptService = bcryptService;
    }

    public async Task<TokenDTO> LoginAsync(LoginDTO loginDTO, string ip)
    {
        var user = await authUserRepo.FindOneByUserNameAsync(loginDTO.UserName);

        if (
            user == null /* ||
            !bcryptService.Verify(loginDTO.Password, user.Password.Value) */
        )
            throw new UnauthorizedAccessException("Credenciais inválidas!");

        if (user.IsDeleted)
            throw new UnauthorizedAccessException("Conta Deletada!");

        if (!user.IsActive)
            throw new UnauthorizedAccessException("Conta Bloqueada!");

        if (!user.Role.IsActive)
            throw new UnauthorizedAccessException("Tipo de Conta Bloqueada!");

        if (user.Role.IsDeleted)
            throw new UnauthorizedAccessException("Tipo de Conta Deletada!");

        return new TokenDTO
        {
            Token = jwtService.GenerateToken([
                new Claim("userId", user.Id.ToString()),
                new Claim("userProfileId", user.UserProfileId.ToString()),
                new Claim("userName", user.UserName),
                new Claim("role", user.Role.Name),
                new Claim("ip", ip)
                
            ])
        };
    }
}
