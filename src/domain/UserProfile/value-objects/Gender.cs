namespace med_consult_api.src.domain;


public class Gender
{
    public GenderType GenderType { get; private set; }

    public Gender(GenderType genderType)
    {
        GenderType = genderType;
    }

    public Gender(string value)
    {

        if (!Enum.TryParse<GenderType>(value, true, out var genderType))
            throw new ArgumentException("Gênero inválido. Deve ser 'Masculino', 'Feminino'.");

        GenderType = genderType;
    }

}