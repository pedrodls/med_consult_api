using System.Text.RegularExpressions;

namespace med_consult_api.src.domain;

public class ResetPasswordCode
{
    public string Value { get; private set; }

    public ResetPasswordCode(string value)
    {
        Value = value;
    }

}