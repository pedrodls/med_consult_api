using med_consult_api.src.application;
using Microsoft.AspNetCore.Mvc;

namespace med_consult_api.src.presentation;

[ApiController]
[Route("api/auth")]
public class AuthServiceController : ControllerBase
{
    IAuthService service;

    public AuthServiceController(IAuthService service)
    {
        this.service = service;
    }

    [HttpPost]
    public async Task<ActionResult<TokenDTO>> Login([FromBody] LoginDTO dto)
    {
        try
        {
            return Ok(await service.LoginAsync(dto));
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
