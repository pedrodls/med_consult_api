
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class ProfessionalQuery : Query
{

    public Guid? UserProfileId { get; set; }
    public Guid? SpecialityId { get; set; }

}
