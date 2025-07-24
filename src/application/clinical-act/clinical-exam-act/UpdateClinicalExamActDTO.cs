namespace med_consult_api.src.application;

public class UpdateClinicalExamActDTO : UpdateClinicalActDTO
{
    public Guid? ExamId { get; set; }
}