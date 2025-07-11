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
}
