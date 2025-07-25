using System.Text.RegularExpressions;

namespace med_consult_api.src.domain;


public class Password
{
    public string Value { get; }

    private Password() { }

    public Password(string value)
    {
        if (!(Regex.IsMatch(value, Pattern.PASSWORD_PATTERN) || Regex.IsMatch(value, Pattern.BCRYPT_HASH_PATTERN)))
            throw new ArgumentException("A senha deve conter no mínimo 8 caracteres, incluindo pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial (como @, $, !, %, , ?, &, ., _, -).");

        Value = value;
    }

    public override string ToString() => Value;

}