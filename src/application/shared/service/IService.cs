using med_consult_api.src.domain;

namespace med_consult_api.src.application;

//T - Tipo da entidade de domínio
//C - Tipo do DTO de criação
//R - Tipo da Response de DTO
//U - Tipo de DTO de atualização

public interface IService<T, C, R, U>
    where T : DomainModel
    where U : UpdateDTO
{
    Task<R> Create(IFactory<T, C, U> factory, C createDTO);
    Task<R> FindOne(Guid id);
    Task<QueryResult<R>> FindAll(Query? queryParams);
    Task<Response> Update(IFactory<T, C, U> factory, Guid id, U updateDTO);
    Task<Response> Delete(Guid id);
}