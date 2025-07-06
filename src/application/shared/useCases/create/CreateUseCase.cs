namespace med_consult_api.src.application;

public class CreateUseCase<T, R> : ICreateUseCase<T, R>
{
    private readonly IRepository<T> repository;
    private readonly IMapper<T, R> mapper;
    public CreateUseCase(IRepository<T> repository, IMapper<T, R> mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<R> ExecuteAsync(T entity)
    {
        return await repository.AddAsync(entity)
            .ContinueWith(task => mapper.MapToDTO(task.Result));
    }
}