
namespace med_consult_api.src.application;

public class PageParams
{
    public int Page { get; set; } = 1;
    public string order { get; set; } = "asc";
    public int PageSize { get; set; } = 10;
    
}
