using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public class Service<T, D, R> : IService<T, D, R>
    where T : DomainModel
    where R : Dto
{
    private readonly IRepository<T> repository;
   /*  private readonly IMapper<T, R> mapper; */

    public Service(IRepository<T> repository/* , IMapper<T, R> mapper */)
    {
        this.repository = repository;
     /*    this.mapper = mapper; */
    }

    public Task<T> Create(IFactory<T, D> factory, D createDTO)
    {
        return new CreateUseCase<T, D>(repository).ExecuteAsync(factory.Create(createDTO));
    }

    public Task<T> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PageResult<T>> FindAll(string? parameters, PageParams? paginateParams)
    {
        return new FindAllUseCase<T>(repository).ExecuteAsync(parameters, paginateParams);
    }

    public Task<T> FindOne(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T> Update(R updateDTO)
    {
        throw new NotImplementedException();
    }
}