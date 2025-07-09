namespace med_consult_api.src.domain;

public class Birthdate
{
    public DateTime Date { get; private set; }

    public Birthdate(DateTime date)
    {
        if (date > DateTime.Now)
            throw new ArgumentException("Data de nascimento não pode ser no futuro.");

        Date = date;
    }

    public int Age => DateTime.Now.Year - Date.Year - (DateTime.Now.DayOfYear < Date.DayOfYear ? 1 : 0);

    public override string ToString() => Date.ToString("dd/MM/yyyy");
}