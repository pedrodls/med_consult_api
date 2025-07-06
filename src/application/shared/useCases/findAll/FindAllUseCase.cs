
namespace med_consult_api.src.application;

public class FindAllUseCase<T, R> : IFindAllUseCase<T, R>
{
    private readonly IRepository<T> repository;
    private readonly IMapper<T, R> mapper;

    public FindAllUseCase(IRepository<T> repository, IMapper<T, R> mapper)
    {
        this.mapper = mapper;
        this.repository = repository;

    }

    public async Task<PageResult<R>> ExecuteAsync(string? parameters, PageParams? paginateParams = null)
    {
        var pageResultT = await repository.FindAllAsync(parameters, paginateParams);

        var mappedItems = pageResultT.Data.Select(mapper.MapToDTO).ToList();

        var result = new PageResult<R>
        {
            Data = mappedItems,
            Total = pageResultT.Total,
            Page = pageResultT.Page,
            PageSize = pageResultT.PageSize
        };

        return result;
    }
}