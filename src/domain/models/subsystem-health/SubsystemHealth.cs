namespace med_consult_api.src.domain;

public class SubsystemHealth : DomainModel
{
    public string Name { get; set; }

    public SubsystemHealth(string name)
        : base()
    {
        Name = name;
    }

    public SubsystemHealth(
           string name,
           Guid? id,
           bool? isActive,
           bool? isDeleted,
           DateTime? createdAt,
           DateTime? updatedAt,
           DateTime? deletedAt
       ) : base(id, isDeleted, isActive, createdAt, updatedAt, deletedAt)
    {
        Name = name;
    }

}