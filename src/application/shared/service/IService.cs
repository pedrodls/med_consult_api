using med_consult_api.src.domain;

namespace med_consult_api.src.application;

//T - Tipo da entidade de domínio
//D - Tipo do DTO de criação
//R - Tipo do DTO comum com tudo
public interface IService<T, D, R>
    where T : DomainModel
    where R : Dto
{
    Task<T> Create(IFactory<T, D> factory, D createDTO);
    Task<T> FindOne(Guid id);
    Task<PageResult<R>> FindAll(string? parameters, PageParams? paginateParams);
    Task<T> Update(R updateDTO);
    Task<T> Delete(Guid id);
}