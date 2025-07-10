using Microsoft.AspNetCore.Mvc;
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.presentation;

[ApiController]
public abstract class DefaultController<TEntity, TCreateDTO, TDTO, TUpdateDTO, TFactory> : ControllerBase
    where TEntity : DomainModel
    where TCreateDTO : class
    where TDTO : class
    where TUpdateDTO : UpdateDTO
    where TFactory : IFactory<TEntity, TCreateDTO, TUpdateDTO>, new()
{
    protected readonly IService<TEntity, TCreateDTO, TDTO, TUpdateDTO> service;

    protected DefaultController(IService<TEntity, TCreateDTO, TDTO, TUpdateDTO> service)
    {
        this.service = service;
    }

    [HttpPost]
    public virtual async Task<ActionResult<TDTO>> Create([FromBody] TCreateDTO dto)
    {
        try
        {
            return await service.Create(new TFactory(), dto);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro ao criar o recurso.", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TDTO>> GetById(Guid id)
    {
        try
        {
            return await service.FindOne(id);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = "Recurso não encontrado.", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public virtual async Task<ActionResult<Response>> Update(Guid id, [FromBody] TUpdateDTO dto)
    {
        try
        {
            return await service.Update(new TFactory(), id, dto);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro ao atualizar o recurso.", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public virtual async Task<ActionResult<Response>> Delete(Guid id)
    {
        try
        {
            return await service.Delete(id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro ao excluir o recurso.", error = ex.Message });
        }
    }
}
