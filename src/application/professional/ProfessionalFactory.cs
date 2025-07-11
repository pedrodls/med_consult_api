using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class ProfessionalFactory : IFactory<Professional, CreateProfessionalDTO, UpdateProfessionalDTO>
{
    public Professional Create(CreateProfessionalDTO dto)
    {
        return new Professional(dto.UserProfileId, dto.SpecialityId);
    }

    public Professional Update(Professional entity, UpdateProfessionalDTO updateDTO)
    {
     
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
