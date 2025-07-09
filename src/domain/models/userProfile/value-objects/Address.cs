namespace med_consult_api.src.domain;

public class  Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }

    public Address(string street, string city, string state)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Rua não pode ser vazia");
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("Cidade não pode ser vazia.");
        if (string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("Estado não pode ser vazio.");
        
        Street = street;
        City = city;
        State = state;
    }

    public override string ToString() => $"{Street}, {City}, {State}";
}