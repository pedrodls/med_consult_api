using med_consult_api.src.application;
using med_consult_api.src.domain;
using med_consult_api.src.infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace med_consult_api.src.presentation;

[Route("api/auth-users")]
public class AuthUserController : DefaultController<AuthUser, CreateAuthUserDTO, AuthUserDTO, UpdateAuthUserDTO, AuthUserFactory>
{
    public AuthUserController(IService<AuthUser, CreateAuthUserDTO, AuthUserDTO, UpdateAuthUserDTO> service)
        : base(service) { }


    [HttpPost]
    [ApiExplorerSettings(IgnoreApi = true)]
    public override async Task<ActionResult<AuthUserDTO>> Create([FromBody] CreateAuthUserDTO dto)
    {
        return await Task.Run(() =>
       {
           return BadRequest(new { error = "Erro", message = "Rota não encontrada!" });
       });
    }

    [HttpPut("{id}")]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public override async Task<ActionResult<Response>> Update(Guid id, [FromBody] UpdateAuthUserDTO dto)
    {
        //Verificar se o Id === id do token
        return await Task.Run(() =>
        {
            return BadRequest(new { error = "Erro", message = "Rota não encontrada!" });
        });
    }

    [HttpPut("me")]
    [Authorize]
    public async Task<ActionResult<Response>> UpdateUserByToken([FromBody] UpdateUserByTokenDTO dto)
    {
        var t = base.Update(new Guid(), new UpdateAuthUserDTO()
        {
            Password = dto.Password,
            UserName = dto.UserName
        });

        //Verificar se o Id === id do token
        return await Task.Run(() =>
        {
            return BadRequest(new { error = "Erro", message = "Rota não encontrada!" });
        });
    }

    [HttpDelete("{id}")]
    [Authorize]
    [Authorize(Roles = "ADMIN")]
    public override async Task<ActionResult<Response>> Delete(Guid id)
    {
        return await Task.Run(() =>
        {
            return BadRequest(new { error = "Erro", message = "Rota não encontrada!" });
        });
    }

    [HttpGet("{id}")]
    [Authorize]
    public override async Task<ActionResult<AuthUserDTO>> GetById(Guid id)
    {
        return await Task.Run(() =>
       {
           return BadRequest(new { error = "Erro", message = "Rota não encontrada!" });
       });
    }


    [HttpGet]
    [Authorize]
    [Authorize(Roles = "ADMIN")]
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
