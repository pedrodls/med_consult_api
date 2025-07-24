using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class ClinicalExamActFactory : IFactory<ClinicalExamAct, CreateClinicalExamActDTO, UpdateClinicalExamActDTO>
{
    public ClinicalExamAct Create(CreateClinicalExamActDTO dto)
    {
        Validate(dto.ExamId.ToString(), "ExamID");
        Validate(dto.ProfessionalId.ToString(), "ProfessionalID");
        Validate(dto.SubsystemHealthId.ToString(), "SubsystemHealthID");

        return new ClinicalExamAct(dto.ExamId, dto.ProfessionalId, dto.SubsystemHealthId);
    }

    public ClinicalExamAct Update(ClinicalExamAct entity, UpdateClinicalExamActDTO updateDTO)
    {
        if (updateDTO.ExamId is not null)
            Validate(updateDTO.ExamId.ToString(), "ExamID");

        if (updateDTO.ProfessionalId is not null)
            Validate(updateDTO.ProfessionalId.ToString(), "ProfessionalID");

        if (updateDTO.SubsystemHealthId is not null)
            Validate(updateDTO.SubsystemHealthId.ToString(), "SubsystemHealthID");

        entity.ExamId = updateDTO.ExamId ?? entity.ExamId;
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
