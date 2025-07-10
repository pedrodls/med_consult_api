namespace med_consult_api.src.application;

public abstract class Dto
{
    public required Guid Id { get; set; }
    public required bool IsActive { get; set; }
    public required bool IsDeleted { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public  DateTime? DeletedAt { get; set; }    
}