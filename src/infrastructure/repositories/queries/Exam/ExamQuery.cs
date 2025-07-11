
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class ExamQuery : Query
{
    public string? Name { get; set; } = null;
    public string? Description { get; set; } = null;

    public Guid? SpecialityId { get; set; }
    public Guid? ExamCategoryId { get; set; }

}
