namespace med_consult_api.src.infrastructure;

public interface IBcryptService
{
    string Hash(string datum);
    bool Verify(string datum, string hash);
}
