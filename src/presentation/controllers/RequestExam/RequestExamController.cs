using med_consult_api.src.application;
using med_consult_api.src.domain;
using med_consult_api.src.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace med_consult_api.src.presentation;

[Route("api/request-exams")]
public class RequestExamController : DefaultController<RequestExam, CreateRequestExamDTO, RequestExamDTO, UpdateRequestExamDTO, RequestExamFactory>
{
    public RequestExamController(IService<RequestExam, CreateRequestExamDTO, RequestExamDTO, UpdateRequestExamDTO> service)
        : base(service) { }


    [HttpPost]
/*     [Authorize]
    [Authorize(Roles = "ADMIN")] */
    public override async Task<ActionResult<RequestExamDTO>> Create([FromBody] CreateRequestExamDTO dto)
    {
        return await base.Create(dto);
    }

    [HttpPut("{id}")]
/*     [Authorize]
    [Authorize(Roles = "ADMIN")] */
    public override async Task<ActionResult<Response>> Update(Guid id, [FromBody] UpdateRequestExamDTO dto)
    {
        return await Task.Run(() =>
        {
            return BadRequest(new { error = "Erro", message = "Rota não encontrada!" });
        });
    }

    [HttpDelete("{id}")]
/*     [Authorize]
    [Authorize(Roles = "ADMIN")] */
    public override async Task<ActionResult<Response>> Delete(Guid id)
    {
        return await Task.Run(() =>
        {
            return BadRequest(new { error = "Erro", message = "Rota não encontrada!" });
        });
    }

    [HttpGet]
/*     [Authorize]
    [Authorize(Roles = "ADMIN")] */
    public async Task<ActionResult<QueryResult<RequestExamDTO>>> GetAll([FromQuery] RequestExamQuery? query = null)
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
