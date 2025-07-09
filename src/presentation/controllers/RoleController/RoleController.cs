using med_consult_api.src.application;
using med_consult_api.src.domain;
using Microsoft.AspNetCore.Mvc;

namespace med_consult_api.src.presentation;

[Route("api/roles")]
[ApiController]
// [Authorize
public class RoleController : ControllerBase
{
    private IService<Role, CreateRoleDTO, RoleDTO, UpdateRoleDTO> roleService;

    public RoleController(IService<Role, CreateRoleDTO, RoleDTO, UpdateRoleDTO> roleService)
    {
        this.roleService = roleService;
    }

    [HttpPost]
    public async Task<ActionResult<RoleDTO>> CreateRole([FromBody] CreateRoleDTO roleDto)
    {
        try
        {
            return await roleService.Create(new RoleFactory(), roleDto);
        }
        catch (Exception ex)
        {
            return StatusCode(400, new
            {
                message = "Ocorreu um erro interno ao processar a solicitação, verifique se este role não existe e tente novamente!",
                error = ex.Message
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<PageResult<RoleDTO>>> GetAllRoles(
    [FromQuery] RoleQuery? query = null)
    {
        try
        {
            var roles = await roleService.FindAll(
            query?.Name, query);

            return Ok(roles);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Ocorreu um erro interno ao processar a solicitação.",
                error = ex.Message
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDTO>> GetRoleById(Guid id)
    {
        try
        {
            return await roleService.FindOne(id);
        }
        catch (Exception ex)
        {
            return StatusCode(404, new
            {
                message = "Não foi possível encontrar o Role!",
                error = ex.Message
            });
        }
    }



    [HttpPut("{id}")]
    public async Task<ActionResult<Response>> UpdateRole(Guid id, [FromBody] UpdateRoleDTO roleDto)
    {
        try
        {
            return await roleService.Update(new RoleFactory(), id, roleDto);
        }
        catch (Exception ex)
        {
            return StatusCode(400, new
            {
                message = "Não foi possível concluir a operação!",
                error = ex.Message
            });
        }

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Response>> DeleteRole(Guid id)
    {
        try
        {
            return await roleService.Delete(id);
        }
        catch (Exception ex)
        {
            return StatusCode(400, new
            {
                message = "Não foi possível concluir a operação!",
                error = ex.Message
            });
        }
    }
}