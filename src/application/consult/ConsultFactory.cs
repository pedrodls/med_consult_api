using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class ConsultFactory : IFactory<Consult, CreateConsultDTO, UpdateConsultDTO>
{
    public Consult Create(CreateConsultDTO dto)
    {
        Validate(dto.Name, "Nome");
        Validate(dto.Description, "Descrição");

        return new Consult(dto.Name.Trim(), dto.Description.Trim(), dto.SpecialityId);
    }

    public Consult Update(Consult entity, UpdateConsultDTO updateDTO)
    {
        if (updateDTO.Name is not null)
            Validate(updateDTO.Name, "Nome");

        if (updateDTO.Description is not null)
            Validate(updateDTO.Description, "Descrição");

        entity.Name = updateDTO.Name?.Trim() ?? entity.Name;
        entity.Description = updateDTO.Description?.Trim() ?? entity.Description;
        entity.SpecialityId = updateDTO.SpecialityId ?? entity.SpecialityId;


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
