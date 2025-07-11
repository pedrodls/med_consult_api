namespace med_consult_api.src.application;

public class CreateProfessionalDTO
{
    public required Guid UserProfileId { get; set; }
    public required Guid SpecialityId { get; set; }

}