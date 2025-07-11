using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class SubsystemHealthFactory : IFactory<SubsystemHealth, CreateSubsystemHealthDTO, UpdateSubsystemHealthDTO>
{
    public SubsystemHealth Create(CreateSubsystemHealthDTO dto)
    {
        Validate(dto.Name, "Nome");

        return new SubsystemHealth(dto.Name.Trim());
    }

    public SubsystemHealth Update(SubsystemHealth entity, UpdateSubsystemHealthDTO updateDTO)
    {
        if (updateDTO.Name is not null)
            Validate(updateDTO.Name, "Nome");

        entity.Name = updateDTO.Name?.Trim() ?? entity.Name;
        
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
