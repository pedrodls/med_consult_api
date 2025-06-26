
namespace med_consult_api.src.application;

public class FindAllUseCase<T, D> : IFindAllUseCase<T, D> 
    
{
    private readonly IRepository<T> repository;

    public FindAllUseCase(IRepository<T> repository)
    {
        this.repository = repository;
    }

    public Task<PageResult<T>> ExecuteAsync(string? parameters, PageParams? paginateParams = null)
    {
        return repository.FindAllAsync(parameters, paginateParams);
    }
}