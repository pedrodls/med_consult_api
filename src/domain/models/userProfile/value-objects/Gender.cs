namespace med_consult_api.src.domain;


public class Gender
{
    public GenderEnumType value { get; private set; }

    private Gender() { }
    public Gender(GenderEnumType GenderEnumType)
    {
        this.value = GenderEnumType;
    }

    public Gender(string value)
    {

        if (!Enum.TryParse<GenderEnumType>(value, true, out var GenderEnumType))
            throw new ArgumentException("Gênero inválido. Deve ser 'Masculino', 'Feminino'.");

        this.value = GenderEnumType;
    }

}