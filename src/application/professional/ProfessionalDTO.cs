namespace med_consult_api.src.application;

public class ProfessionalDTO : Dto
{
    public required Guid UserProfileId { get; set; }
    public required Guid SpecialityId { get; set; }

}