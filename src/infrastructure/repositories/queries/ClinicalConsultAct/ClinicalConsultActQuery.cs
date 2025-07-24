
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class ClinicalConsultActQuery : Query
{
    public Guid? ConsultId { get; set; }
    public Guid? ProfessionalId { get; set; }
    public Guid? SubsystemHealthId { get; set; }

}
