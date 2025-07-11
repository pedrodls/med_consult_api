namespace med_consult_api.src.domain;

public class Consult : DomainModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Speciality? Speciality { get;  set; }
    public Guid SpecialityId { get; set; }

    public Consult(string name, string description, Guid SpecialityId)
        : base()
    {
        Name = name;
        Description = description;
        this.SpecialityId = SpecialityId;
    }

    public Consult(
           string name,
           string description,
           Guid SpecialityId,
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
        this.SpecialityId = SpecialityId;
    }

}