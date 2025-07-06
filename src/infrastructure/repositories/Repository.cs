
using med_consult_api.src.application;
using med_consult_api.src.domain;
using Microsoft.EntityFrameworkCore;

namespace med_consult_api.src.infrastructure;

public class Repository<T> : IRepository<T> where T : DomainModel
{
    private readonly DatabaseContext context;
    private readonly DbSet<T> dbSet;

    public Repository(DatabaseContext context)
    {
        this.context = context;
        dbSet = context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        return await Task.Run(() =>
        {
            dbSet.Add(entity);

            context.SaveChanges();

            return entity;
        });
    }

    public async Task<Response> DeleteAsync(Guid id)
    {
        return await Task.Run(() =>
        {
            T? entity = dbSet.Find(id);

            if (entity == null)
                return Response.Create(id, $"Entidade com ID = {id} não encontrada.");

            entity.MarkAsDeleted();

            context.SaveChanges();

            return Response.Create(id, $"Entidade com ID '{id}' foi eliminada.");

        });
    }

    public async Task<PageResult<T>> FindAllAsync(string? parameters, PageParams? paginateParams = null)
    {

        var query = dbSet.AsQueryable();

        if (paginateParams != null)
        {
            query = query
                .OrderBy(x => paginateParams.order)
                .Skip((paginateParams.Page - 1) * paginateParams.PageSize)
                .Take(paginateParams.PageSize);
        }

        var data = await query.ToListAsync();
        var total = await dbSet.CountAsync();

        return new PageResult<T>
        {
            Data = data,
            Total = total,
            Page = paginateParams?.Page ?? 1,
            PageSize = paginateParams?.PageSize ?? 10
        };
    }


    public async Task<T> FindOneAsync(Guid id)
    {
        return await dbSet.FindAsync(id) ?? throw new KeyNotFoundException($"Entidade com ID {id} não encontrada!");
    }

    public async Task<Response> UpdateAsync(Guid id, T entity)
    {
        var existingEntity = await FindOneAsync(id);

        context.Entry(existingEntity).CurrentValues.SetValues(entity);

        await context.SaveChangesAsync();

        return Response.Create(id, $"Entidade com ID '{id}' foi atualizada.");
    }
}
