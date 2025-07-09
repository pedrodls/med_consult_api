
namespace med_consult_api.src.application;

public class PageParams
{
    public int Page { get; set; } = 1;
    public string Order { get; set; } = "ASC";
    public int PageSize { get; set; } = 10;
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

}
