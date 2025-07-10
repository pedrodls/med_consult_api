using System.Text.RegularExpressions;

namespace med_consult_api.src.domain;

public class ResetPasswordCode
{
    public string? Value { get; private set; }

    private ResetPasswordCode()
    {

    }

    public ResetPasswordCode(string? value)
    {
        Value = value;
    }
    
    public void Generate()
    {
        Value = "GN-" + (DateTime.Now.ToLocalTime().Ticks / 10 % 1000) + "-Code";
    }


    public override string ToString() => Value;

}