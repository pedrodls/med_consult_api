namespace med_consult_api.src.domain;


public class Gender
{
    public GenderEnumType GenderEnumType { get; private set; }

    public Gender(GenderEnumType GenderEnumType)
    {
        this.GenderEnumType = GenderEnumType;
    }

    public Gender(string value)
    {

        if (!Enum.TryParse<GenderEnumType>(value, true, out var GenderEnumType))
            throw new ArgumentException("Gênero inválido. Deve ser 'Masculino', 'Feminino'.");

        this.GenderEnumType = GenderEnumType;
    }

}