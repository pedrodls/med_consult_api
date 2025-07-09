namespace med_consult_api.src.domain;

public class FullName
{
    public string FirstName { get; }
    public string LastName { get; }

    private FullName() { }

    public FullName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Nome e sobrenome não podem ser vazios.");

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
    }

    public override string ToString() => $"{FirstName} {LastName}";
}
