namespace med_consult_api.src.application;

public interface IRepository<T>
{
    Task<T> AddAsync(T entity);
    Task<T> FindOneAsync(Guid id);
    Task<PageResult<T>> FindAllAsync(string? parameters, PageParams? paginateParams = null);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}