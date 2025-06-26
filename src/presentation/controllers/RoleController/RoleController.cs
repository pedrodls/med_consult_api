using med_consult_api.src.application;
using med_consult_api.src.domain;
using Microsoft.AspNetCore.Mvc;

namespace med_consult_api.src.presentation;

[Route("api/roles")]
[ApiController]
// [Authorize
public class RoleController : ControllerBase
{
    private IService<Role, CreateRoleDTO, RoleDTO> roleService;

    public RoleController(IService<Role, CreateRoleDTO, RoleDTO> roleService)
    {
        this.roleService = roleService;
    }

    [HttpGet]
    public async Task<ActionResult<PageResult<RoleDTO>>> GetAllRoles(
    [FromQuery] RoleQuery? query = null)
    {

        var roles = await roleService.FindAll(
            query?.Name,
            new PageParams
            {
                Page = query.Page,
                PageSize = query.PageSize,
                order = query.order
            }
        );

        /* [
            new RoleMapper().MapToDTO(new Role("Admin", "Administrator role")),
        new RoleMapper().MapToDTO(new Role("User", "Regular user role"))
        ];
 */
        return Ok(roles);
    }

    /* [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await roleService.GetAllRolesAsync();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(Guid id)
    {
        var role = await roleService.GetRoleByIdAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    } */

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleDTO roleDto)
    {
        Role createdRole = await roleService.Create(new RoleFactory(), roleDto);

        System.Console.WriteLine($"Created Role: {createdRole}");
        if (createdRole == null)
        {
            return BadRequest("Role creation failed.");
        }

        return BadRequest("Role creation failed.");

        //return new RoleMapper().MapToDTO(createdRole);
    }

    /*  [HttpPut("{id}")]
     public async Task<IActionResult> UpdateRole(Guid id, [FromBody] RoleDto roleDto)
     {
         if (!ModelState.IsValid)
         {
             return BadRequest(ModelState);
         }

         var updatedRole = await roleService.UpdateRoleAsync(id, roleDto);
         if (updatedRole == null)
         {
             return NotFound();
         }

         return Ok(updatedRole);
     }

     [HttpDelete("{id}")]
     public async Task<IActionResult> DeleteRole(Guid id)
     {
         var result = await roleService.DeleteRoleAsync(id);
         if (!result)
         {
             return NotFound();
         }

         return NoContent();
     } */
}