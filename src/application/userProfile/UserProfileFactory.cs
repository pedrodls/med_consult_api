using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class UserProfileFactory : IFactory<UserProfile, CreateUserProfileDTO, UpdateUserProfileDTO>
{
    public UserProfile Create(CreateUserProfileDTO dto)
    {
        try
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.Avatar))
                throw new ArgumentException("Avatar não pode ser vazio.", nameof(dto.Avatar));
            if (string.IsNullOrWhiteSpace(dto.FirstName))
                throw new ArgumentException("Primeiro nome não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(dto.LastName))
                throw new ArgumentException("Último nome não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(dto.Gender))
                throw new ArgumentException("Gênero não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new ArgumentException("Email não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(dto.Telephone))
                throw new ArgumentException("Telefone não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(dto.Street) ||
                string.IsNullOrWhiteSpace(dto.City) ||
                string.IsNullOrWhiteSpace(dto.State))
                throw new ArgumentException("Endereço incompleto.");

            // Conversão de tipos primitivos para objetos de valor
            var fullName = new FullName(dto.FirstName, dto.LastName);
            var birthdate = new Birthdate(dto.Birthdate);
            var gender = new Gender(dto.Gender);
            var telephone = new Telephone(dto.Telephone);
            var email = new Email(dto.Email);
            var address = new Address(dto.Street, dto.City, dto.State);

            return new UserProfile(
                dto.Avatar,
                fullName,
                birthdate,
                gender,
                telephone,
                email,
                address,
                authUser: null,
                authUserId: null
            );
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public UserProfile Update(UserProfile existingProfile, UpdateUserProfileDTO dto)
    {
        try
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (existingProfile == null)
                throw new ArgumentNullException(nameof(existingProfile));

            // Atualiza apenas os campos enviados (se não forem nulos)
            if (!string.IsNullOrWhiteSpace(dto.Avatar))
                existingProfile.GetType().GetProperty("Avatar")?.SetValue(existingProfile, dto.Avatar);

            if (!(string.IsNullOrWhiteSpace(dto.FirstName) || string.IsNullOrWhiteSpace(dto.LastName)))
            {
                var first = dto.FirstName ?? existingProfile.FullName.FirstName;
                var last = dto.LastName ?? existingProfile.FullName.LastName;

                existingProfile.FullName = new FullName(first, last);
            }

            if (dto.Birthdate.HasValue)
                existingProfile.Birthdate = new Birthdate(dto.Birthdate.Value);

            if (!string.IsNullOrWhiteSpace(dto.Gender))
                existingProfile.Gender = new Gender(dto.Gender);

            if (!string.IsNullOrWhiteSpace(dto.Telephone))
                existingProfile.Telephone = new Telephone(dto.Telephone);

            if (!string.IsNullOrWhiteSpace(dto.Email))
                existingProfile.Email = new Email(dto.Email);

            if (!(string.IsNullOrWhiteSpace(dto.Street) || string.IsNullOrWhiteSpace(dto.City) || string.IsNullOrWhiteSpace(dto.State)))
            {
                var street = dto.Street ?? existingProfile.Address.Street;
                var city = dto.City ?? existingProfile.Address.City;
                var state = dto.State ?? existingProfile.Address.State;

                existingProfile.Address = new Address(street, city, state);
            }

            if (dto.IsActive.HasValue)
            {
                if (dto.IsActive.Value)
                    existingProfile.Activate();
                else
                    existingProfile.Deactivate();
            }

            existingProfile.Touch();

            return existingProfile;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
