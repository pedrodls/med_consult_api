namespace med_consult_api.src.application;

public class UpdateExamDTO : UpdateDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? SpecialityId { get; set; }
    public Guid? ExamCategoryId { get; set; }
}