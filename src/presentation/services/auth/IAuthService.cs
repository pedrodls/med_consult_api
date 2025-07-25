using med_consult_api.src.application;

namespace med_consult_api.src.presentation;

public interface IAuthService
{
    public Task<TokenDTO> LoginAsync(LoginDTO loginDTO, string ip);
    public Task<AuthUserDTO> CreateUserAsync(CreateAuthUserDTO loginDTO);
    public Task<Response> UpdateUserRoleAsync(UpdateUserRoleDTO updateRoleDTO);
}
