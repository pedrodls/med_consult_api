using System.Text.RegularExpressions;

namespace med_consult_api.src.domain;


public class Password
{
    public string Value { get; }

    private Password() { }

    public Password(string value)
    {
        if (!Regex.IsMatch(value, Pattern.PASSWORD_PATTERN))
            throw new ArgumentException("Formato de email inválido.");

        Value = value;
    }

    public override string ToString() => Value;

}