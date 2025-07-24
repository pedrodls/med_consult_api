using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class ClinicalConsultActFactory : IFactory<ClinicalConsultAct, CreateClinicalConsultActDTO, UpdateClinicalConsultActDTO>
{
    public ClinicalConsultAct Create(CreateClinicalConsultActDTO dto)
    {
        Validate(dto.ConsultId.ToString(), "ConsultID");
        Validate(dto.ProfessionalId.ToString(), "ProfessionalID");
        Validate(dto.SubsystemHealthId.ToString(), "SubsystemHealthID");

        return new ClinicalConsultAct(dto.ConsultId, dto.ProfessionalId, dto.SubsystemHealthId);
    }

    public ClinicalConsultAct Update(ClinicalConsultAct entity, UpdateClinicalConsultActDTO updateDTO)
    {
        if (updateDTO.ConsultId is not null)
            Validate(updateDTO.ConsultId.ToString(), "ConsultID");

        if (updateDTO.ProfessionalId is not null)
            Validate(updateDTO.ProfessionalId.ToString(), "ProfessionalID");

        if (updateDTO.SubsystemHealthId is not null)
            Validate(updateDTO.SubsystemHealthId.ToString(), "SubsystemHealthID");

        entity.ConsultId = updateDTO.ConsultId ?? entity.ConsultId;
        entity.ProfessionalId = updateDTO.ProfessionalId ?? entity.ProfessionalId;
        entity.SubsystemHealthId = updateDTO.SubsystemHealthId ?? entity.SubsystemHealthId;


        bool state = updateDTO.IsActive ?? entity.IsActive;

        if (state)
            entity.Activate();
        else
            entity.Deactivate();

        entity.Touch();

        return entity;
    }

    private void Validate(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{fieldName} não pode estar vazio.");
    }
}
