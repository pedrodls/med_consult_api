using med_consult_api.src.application;
using med_consult_api.src.domain;
using med_consult_api.src.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace med_consult_api.src.presentation;

[Route("api/users-profiles")]
[ApiController]
public class UserProfileController : DefaultController<UserProfile,
    CreateUserProfileDTO,
    UserProfileDTO,
    UpdateUserProfileDTO,
    UserProfileFactory>
{
    public UserProfileController(
        IService<UserProfile, CreateUserProfileDTO, UserProfileDTO, UpdateUserProfileDTO> service)
        : base(service) { }

    [HttpGet]
    public async Task<ActionResult<QueryResult<UserProfileDTO>>> GetAll([FromQuery] UserProfileQuery? query = null)
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
