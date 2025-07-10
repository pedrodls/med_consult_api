using med_consult_api.src.application;
using med_consult_api.src.domain;
using med_consult_api.src.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace med_consult_api.src.presentation;

[Route("api/auth-users")]
public class AuthUserController : DefaultController<AuthUser, CreateAuthUserDTO, AuthUserDTO, UpdateAuthUserDTO, AuthUserFactory>
{
    public AuthUserController(IService<AuthUser, CreateAuthUserDTO, AuthUserDTO, UpdateAuthUserDTO> service)
        : base(service) { }


    [HttpGet]
    public async Task<ActionResult<QueryResult<AuthUserDTO>>> GetAll([FromQuery] AuthUserQuery? query = null)
    {
        try
        {
            return Ok(await service.FindAll(query));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Erro ao listar os dados.",
                error = ex.Message
            });
        }
    }
}
