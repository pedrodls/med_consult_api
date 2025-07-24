namespace med_consult_api.src.application;

public class CreateClinicalExamActDTO : CreateClinicalActDTO
{
    public required Guid ExamId { get; set; }
}