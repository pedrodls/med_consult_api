using med_consult_api.src.application;
using med_consult_api.src.domain;
using med_consult_api.src.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace med_consult_api.src.presentation;

[Route("api/roles")]
public class RoleController : DefaultController<Role, CreateRoleDTO, RoleDTO, UpdateRoleDTO, RoleFactory>
{
    public RoleController(IService<Role, CreateRoleDTO, RoleDTO, UpdateRoleDTO> service)
        : base(service) { }

    [HttpGet]
    public async Task<ActionResult<QueryResult<RoleDTO>>> GetAll([FromQuery] RoleQuery? query = null)
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
