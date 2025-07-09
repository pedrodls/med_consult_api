
namespace med_consult_api.src.application;

public class Query
{
    public int Page { get; set; } = 1;
    public string OrderBy { get; set; } = "CreatedAt";
    public string Order { get; set; } = "DESC";
    public int PageSize { get; set; } = 10;
    public bool? IsActive { get; set; } = true;
    public bool? IsDeleted { get; set; } = null;
    public DateTime? CreatedAt { get; set; } = null;
    public DateTime? UpdatedAt { get; set; } = null;
    public DateTime? DeletedAt { get; set; } = null;

}
