namespace med_consult_api.src.application;

public class ExamDTO : Dto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Guid SpecialityId { get; set; }
    public required Guid ExamCategoryId { get; set; }
}