namespace med_consult_api.src.domain;

public class Role : DomainModel
{
    
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Role(string name, string description)
        : base()
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome não pode ser vazio ou nulo.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Descrição não pode ser vazia ou nulo.");

        Name = name.ToUpper();
        Description = description;
    }

    public Role(
           string name,
           string description,
           Guid? id,
           bool? isActive,
           bool? isDeleted,
           DateTime? createdAt,
           DateTime? updatedAt,
           DateTime? deletedAt
       ) : base(id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, \n[Role] Name: {Name}, Description: {Description}";
    }
}