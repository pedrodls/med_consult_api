

namespace med_consult_api.src.domain;

public static class Pattern
{

    public const string PASSWORD_PATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&._\-])[A-Za-z\d@$!%*?&._\-]{8,}$";

    public const string BCRYPT_HASH_PATTERN = @"^\$2[aby]?\$\d{2}\$[./A-Za-z0-9]{53}$";

    public const string EMAIL_PATTERN = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
}