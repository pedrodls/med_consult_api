namespace med_consult_api.src.application;

public class DeleteUseCase<T, R> : IDeleteUseCase
{
    private readonly IRepository<T> repository;
    public DeleteUseCase(IRepository<T> repository)
    {
        this.repository = repository;
    }

    public async Task<Response> ExecuteAsync(Guid id)
    {
        return await repository.DeleteAsync(id);
    }
}