
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class ClinicalConsultActQueryRepository : IQueryRepository<ClinicalConsultAct>
{
    public IQueryable<ClinicalConsultAct> GetWhereClause(Query? queryParams, IQueryable<ClinicalConsultAct> queryModel)
    {
        ClinicalConsultActQuery? ConsultQuery = queryParams as ClinicalConsultActQuery;

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.ConsultId.ToString()))
            queryModel = queryModel.Where(r => r.ConsultId.Equals(ConsultQuery.ConsultId));

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.ProfessionalId.ToString()))
            queryModel = queryModel.Where(r => r.ProfessionalId.Equals(ConsultQuery.ProfessionalId));

        if (!string.IsNullOrWhiteSpace(ConsultQuery?.SubsystemHealthId.ToString()))
            queryModel = queryModel.Where(r => r.SubsystemHealthId.Equals(ConsultQuery.SubsystemHealthId));

        return queryModel;
    }
}