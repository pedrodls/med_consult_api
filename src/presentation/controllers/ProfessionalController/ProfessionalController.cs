using med_consult_api.src.application;
using med_consult_api.src.domain;
using med_consult_api.src.infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace med_consult_api.src.presentation;

[Route("api/professionals")]
public class ProfessionalController : DefaultController<Professional, CreateProfessionalDTO, ProfessionalDTO, UpdateProfessionalDTO, ProfessionalFactory>
{
    public ProfessionalController(IService<Professional, CreateProfessionalDTO, ProfessionalDTO, UpdateProfessionalDTO> service)
        : base(service) { }


    [HttpPost]
    /* [Authorize]
    [Authorize(Roles = "ADMIN")] */
    public override async Task<ActionResult<ProfessionalDTO>> Create([FromBody] CreateProfessionalDTO dto)
    {
        return await base.Create(dto);
    }

    [HttpPut("{id}")]
   /*  [Authorize]
    [Authorize(Roles = "ADMIN")] */
    public override async Task<ActionResult<Response>> Update(Guid id, [FromBody] UpdateProfessionalDTO dto)
    {
        return await Task.Run(() =>
        {
            return BadRequest(new { error = "Erro", message = "Rota não encontrada!" });
        });
    }

    [HttpDelete("{id}")]
   /*  [Authorize]
    [Authorize(Roles = "ADMIN")] */
    public override async Task<ActionResult<Response>> Delete(Guid id)
    {
        return await Task.Run(() =>
        {
            return BadRequest(new { error = "Erro", message = "Rota não encontrada!" });
        });
    }

    [HttpGet]
  /*   [Authorize]
    [Authorize(Roles = "ADMIN")] */
    public async Task<ActionResult<QueryResult<ProfessionalDTO>>> GetAll([FromQuery] ProfessionalQuery? query = null)
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
