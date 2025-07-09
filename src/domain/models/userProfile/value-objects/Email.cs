using System.Text.RegularExpressions;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;

namespace med_consult_api.src.domain;

public class Email
{
    public string  Value { get; private set; }

    private Email() { }
    
    public Email(string value)
    {
        if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Formato de email inválido.");

        Value = value.ToLowerInvariant(); // normaliza o email para minúsculas
    }
    
    public override string ToString() => Value;
}