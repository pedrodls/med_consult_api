using med_consult_api.src.application;
using med_consult_api.src.domain;
using med_consult_api.src.infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace med_consult_api.src.presentation;

[Route("api/subsystem-health")]
public class SubsystemHealthController : DefaultController<SubsystemHealth, CreateSubsystemHealthDTO, SubsystemHealthDTO, UpdateSubsystemHealthDTO, SubsystemHealthFactory>
{
    public SubsystemHealthController(IService<SubsystemHealth, CreateSubsystemHealthDTO, SubsystemHealthDTO, UpdateSubsystemHealthDTO> service)
        : base(service) { }


    [HttpPost]
    [Authorize]
    [Authorize(Roles = "ADMIN")]
    public override async Task<ActionResult<SubsystemHealthDTO>> Create([FromBody] CreateSubsystemHealthDTO dto)
    {
        return await base.Create(dto);
    }

    [HttpPut("{id}")]
    [Authorize]
    [Authorize(Roles = "ADMIN")]
    public override async Task<ActionResult<Response>> Update(Guid id, [FromBody] UpdateSubsystemHealthDTO dto)
    {
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

    [HttpGet]
    [Authorize]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult<QueryResult<SubsystemHealthDTO>>> GetAll([FromQuery] SubsystemHealthQuery? query = null)
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
