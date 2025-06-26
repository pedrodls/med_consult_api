
using med_consult_api.src.application;
using med_consult_api.src.domain;

namespace med_consult_api.src.infrastructure;

public class Repository<T> : IRepository<T> where T : DomainModel
{
    private readonly DatabaseContext context;

    public Repository(DatabaseContext context)
    {
        this.context = context;
    }

    public Task<T> AddAsync(T entity)
    {
        return Task.Run(() =>
        {
            /*      context.Set<T>().Add(entity);
                 context.SaveChanges(); */
            return entity;
        });
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PageResult<T>> FindAllAsync(string? parameters, PageParams? paginateParams = null)
    {
        return Task.Run(() =>
        {
            // Simulate fetching data from the database
            var data = context.Set<T>().AsQueryable();

            // Apply pagination if provided
            if (paginateParams != null)
            {
                data = data.Skip((paginateParams.Page - 1) * paginateParams.PageSize)
                           .Take(paginateParams.PageSize);
            }

            // Create a PageResult object
            var result = new PageResult<T>
            {
                Data = data.ToList(),
                Total = context.Set<T>().Count(),
                Page = paginateParams?.Page ?? 1,
                PageSize = paginateParams?.PageSize ?? 10
            };

            return result;
        });
    }


    public Task<T> FindOneAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
