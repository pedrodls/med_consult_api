namespace med_consult_api.src.application;

public interface IRepository<T>
{
    Task<T> AddAsync(T entity);
    Task<T> FindOneAsync(Guid id);
    Task<QueryResult<T>> FindAllAsync(Query? queryParams = null);
    Task<Response> UpdateAsync(Guid id, T entity);
    Task<Response> DeleteAsync(Guid id);
}