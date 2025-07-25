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

    public async Task<AuthUserDTO> CreateUserAsync(CreateAuthUserDTO dto)
    {
        dto.Password = bcryptService.Hash(dto.Password);

        AuthUser authUser = await authUserRepo.AddAsync(new AuthUserFactory().Create(dto));

        return new AuthUserMapper().MapToDTO(authUser);
    }

    public async Task<TokenDTO> LoginAsync(LoginDTO loginDTO, string ip)
    {
        var user = await authUserRepo.FindOneByUserNameAsync(loginDTO.UserName);

        if (
            user == null ||
            !bcryptService.Verify(loginDTO.Password, user.Password.Value)
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

    public async Task<Response> UpdateUserRoleAsync(UpdateUserRoleDTO updateRoleDTO)
    {
        AuthUser authUser = await authUserRepo.FindOneAsync(updateRoleDTO.RoleId) ?? throw new Exception("Usuário não encontrado!");
        
        authUser = new AuthUserFactory().Update(authUser, new UpdateAuthUserDTO() { RoleId = updateRoleDTO.RoleId });

        return await authUserRepo.UpdateAsync(authUser.Id, new AuthUserFactory().Update(authUser, new UpdateAuthUserDTO() { RoleId = updateRoleDTO.RoleId }));
    }
}
