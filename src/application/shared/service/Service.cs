using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class Service<T, C, R, U> : IService<T, C, R, U>
    where T : DomainModel
    where U : UpdateDTO
{
    private readonly IRepository<T> repository;
    private readonly IMapper<T, R> mapper;

    public Service(IRepository<T> repository, IMapper<T, R> mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public Task<R> Create(IFactory<T, C, U> factory, C createDTO)
    {
        return new CreateUseCase<T, R>(repository, mapper).ExecuteAsync(factory.Create(createDTO));
    }

    public async Task<Response> Update(IFactory<T, C, U> factory, Guid id, U updateDTO)
    {
   
            R entityDataFound = await FindOne(id);

            return await new UpdateUseCase<T, R>(repository).ExecuteAsync(id, factory.Update(mapper.MapToEntity(entityDataFound), updateDTO));
       
    }

    public Task<PageResult<R>> FindAll(string? parameters, PageParams? paginateParams)
    {
        return new FindAllUseCase<T, R>(repository, mapper).ExecuteAsync(parameters, paginateParams);
    }

    public async Task<Response> Delete(Guid id)
    {
        return await new DeleteUseCase<T, R>(repository).ExecuteAsync(id);
    }

    public async Task<R> FindOne(Guid id)
    {
        return await new FindOneUseCase<T, R>(repository, mapper).ExecuteAsync(id);
    }


}