
namespace med_consult_api.src.domain;

public static class UserProfileFactory
{
    private static void ValidateNullOrEmpty<T>(T value, string paramName)
    {
        if (value == null)
            throw new ArgumentNullException(paramName, $"{paramName} não pode ser nulo.");
    }
    public static UserProfile Create(
        string avatar,
        FullName fullName,
        Birthdate birthdate,
        Gender gender,
        Telephone telephone,
        Email email,
        Address address,
        AuthUser? authUser)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(avatar))
                throw new ArgumentException("Avatar não pode ser vazia.", nameof(avatar));

            ValidateNullOrEmpty(fullName, nameof(fullName));
            ValidateNullOrEmpty(birthdate, nameof(birthdate));
            ValidateNullOrEmpty(gender, nameof(gender));
            ValidateNullOrEmpty(telephone, nameof(telephone));
            ValidateNullOrEmpty(email, nameof(email));
            ValidateNullOrEmpty(address, nameof(address));

            return new UserProfile(avatar, fullName, birthdate, gender, telephone, email, address, authUser, authUser?.Id);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(
                "Erro ao criar o perfil do usuário. Verifique os dados informados.",
                ex);
        }
    }

}