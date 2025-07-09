using System.Text.RegularExpressions;

namespace med_consult_api.src.domain;

public class VerificationCode
{
    public string Value { get; private set; }

    public VerificationCode(string value)
    {
        Value = value;
    }

}