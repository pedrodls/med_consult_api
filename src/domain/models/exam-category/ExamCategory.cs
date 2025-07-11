namespace med_consult_api.src.domain;

public class ExamCategory : DomainModel
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ExamCategory(string name, string description)
        : base()
    {
        Name = name;
        Description = description;
    }

    public ExamCategory(
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

}