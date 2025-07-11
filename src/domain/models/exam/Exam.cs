namespace med_consult_api.src.domain;

public class Exam : DomainModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Speciality? Speciality { get; set; }
    public Guid SpecialityId { get; set; }
    public ExamCategory? ExamCategory { get; set; }
    public Guid ExamCategoryId { get; set; }

    public Exam(string name, string description, Guid SpecialityId, Guid ExamCategoryId)
        : base()
    {
        Name = name;
        Description = description;
        this.SpecialityId = SpecialityId;
        this.ExamCategoryId = ExamCategoryId;
    }

    public Exam(
           string name,
           string description,
           Guid SpecialityId,
           Guid ExamCategoryId,
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
        this.ExamCategoryId = ExamCategoryId;
    }

}