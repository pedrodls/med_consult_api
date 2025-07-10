namespace med_consult_api.src.infrastructure;

public class BcryptService : IBcryptService
{
    public string Hash(string datum)
    {
        return BCrypt.Net.BCrypt.HashPassword(datum);
    }

    public bool Verify(string datum, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(datum, hash);
    }
}
