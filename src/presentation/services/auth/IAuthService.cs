namespace med_consult_api.src.presentation;

public interface IAuthService
{
    public Task<TokenDTO> LoginAsync(LoginDTO loginDTO, string ip);
}
