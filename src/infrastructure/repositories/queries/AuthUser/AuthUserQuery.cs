
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class AuthUserQuery : Query
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public Guid? RoleId { get; set; }

}
