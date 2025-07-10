using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class UserProfileFactory : IFactory<UserProfile, CreateUserProfileDTO, UpdateUserProfileDTO>
{
    public UserProfile Create(CreateUserProfileDTO dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        ValidateString(dto.Avatar, "Avatar");
        ValidateString(dto.FirstName, "Primeiro nome");
        ValidateString(dto.LastName, "Último nome");
        ValidateString(dto.Gender, "Gênero");
        ValidateString(dto.Email, "Email");
        ValidateString(dto.Telephone, "Telefone");
        ValidateString(dto.Street, "Rua");
        ValidateString(dto.City, "Cidade");
        ValidateString(dto.State, "Estado");

        var fullName = new FullName(dto.FirstName, dto.LastName);
        var birthdate = new Birthdate(dto.Birthdate);
        var gender = new Gender(dto.Gender);
        var telephone = new Telephone(dto.Telephone);
        var email = new Email(dto.Email);
        var address = new Address(dto.Street, dto.City, dto.State);

        return new UserProfile(dto.Avatar, fullName, birthdate, gender, telephone, email, address, null, null);
    }

    public UserProfile Update(UserProfile existingProfile, UpdateUserProfileDTO dto)
    {
        if (dto == null) throw new ArgumentNullException(nameof(dto));
        if (existingProfile == null) throw new ArgumentNullException(nameof(existingProfile));

        if (!string.IsNullOrWhiteSpace(dto.Avatar))
            existingProfile.Avatar = dto.Avatar;

        if (!string.IsNullOrWhiteSpace(dto.FirstName) || !string.IsNullOrWhiteSpace(dto.LastName))
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

        var street = dto.Street ?? existingProfile.Address.Street;
        var city = dto.City ?? existingProfile.Address.City;
        var state = dto.State ?? existingProfile.Address.State;
        existingProfile.Address = new Address(street, city, state);

        if (dto.IsActive.HasValue)
        {
            if (dto.IsActive.Value) existingProfile.Activate();
            else existingProfile.Deactivate();
        }

        existingProfile.Touch();
        return existingProfile;
    }

    private void ValidateString(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{fieldName} não pode ser vazio.");
    }
}

