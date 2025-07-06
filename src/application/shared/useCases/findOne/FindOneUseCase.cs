
namespace med_consult_api.src.application;

public class FindOneUseCase<T, R> : IFindOneUseCase<R>
{
    private readonly IRepository<T> repository;
    private readonly IMapper<T, R> mapper;

    public FindOneUseCase(IRepository<T> repository, IMapper<T, R> mapper)
    {
        this.mapper = mapper;
        this.repository = repository;

    }

    public async Task<R> ExecuteAsync(Guid id)
    {
        T entityData = await repository.FindOneAsync(id);
        
        return mapper.MapToDTO(entityData);
    }
}