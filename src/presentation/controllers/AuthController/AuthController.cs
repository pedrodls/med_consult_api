using med_consult_api.src.application;
using Microsoft.AspNetCore.Mvc;

namespace med_consult_api.src.presentation;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    IAuthService service;

    public AuthController(IAuthService service)
    {
        this.service = service;
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<TokenDTO>> Login([FromBody] LoginDTO dto)
    {
        try
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            return Ok(await service.LoginAsync(dto, ipAddress!));
        }
        catch (Exception ex)
        {
            return StatusCode(404, new
            {
                message = "Erro ao fazer login",
                error = ex.Message
            });
        }
    }

    [HttpPost]
    [Route("create-user")]
    public async Task<ActionResult<AuthUserDTO>> CreateUser([FromBody] CreateAuthUserDTO dto)
    {
        try
        {
            return Ok(await service.CreateUserAsync(dto));
        }
        catch (Exception ex)
        {
            return StatusCode(404, new
            {
                message = "Erro ao criar uma conta!",
                error = ex.Message
            });
        }
    }

    [HttpPost]
    [Route("update-user-role")]
    public async Task<ActionResult<Response>> UpdateUserRole([FromBody] UpdateUserRoleDTO dto)
    {
        try
        {
            return Ok(await service.UpdateUserRoleAsync(dto));
        }
        catch (Exception ex)
        {
            return StatusCode(404, new
            {
                message = "Erro ao atualizar o tipo de conta do usuário!",
                error = ex.Message
            });
        }
    }
}
