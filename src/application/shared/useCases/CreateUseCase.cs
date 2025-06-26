namespace med_consult_api.src.application;

public class CreateUseCase<T, D> : IUseCase<T, D>
{
    private readonly IRepository<T> repository;
    public CreateUseCase(IRepository<T> repository)
    {
        this.repository = repository;
    }

    public Task<T> ExecuteAsync(T entity)
    {
        return repository.AddAsync(entity);
    }
}