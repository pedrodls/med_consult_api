using System.Text.RegularExpressions;

namespace med_consult_api.src.domain;
public class Telephone
{
    public string Value { get; private set; }

    private Telephone() { }

    public Telephone(string value)
    {
        if (!Regex.IsMatch(value, @"^\+?[1-9]\d{1,14}$"))
            throw new ArgumentException("Formato de telefone inválido.");

        Value = value;
    }

    public override string ToString() => Value;
}
