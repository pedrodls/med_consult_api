namespace med_consult_api.src.application;

public class CreateExamDTO
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Guid SpecialityExamId { get; set; }
    public required Guid ExamCategoryId { get; set; }
}