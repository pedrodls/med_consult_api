namespace med_consult_api.src.application;

public class UpdateUseCase<T, R> : IUpdateUseCase<T>
{
    private readonly IRepository<T> repository;
    public UpdateUseCase(IRepository<T> repository)
    {
        this.repository = repository;
    }

    public async Task<Response> ExecuteAsync(Guid id, T entity)
    {
        return await repository.UpdateAsync(id, entity);
    }
}