using System.Text.RegularExpressions;

namespace med_consult_api.src.domain;

public class Password
{
    public string Value { get; }

    public Password(string value)
    {
        if (!Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&._\-])[A-Za-z\d@$!%*?&._\-]{8,}$"))
            throw new ArgumentException("Formato de email inválido.");

        Value = value;
    }

    public override string ToString() => Value;

}