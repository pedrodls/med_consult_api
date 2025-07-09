
using med_consult_api.src.application;
using med_consult_api.src.domain;
using med_consult_api.src.presentation;
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

    public async Task<QueryResult<T>> FindAllAsync(Query? queryParams = null)
    {

        IQueryable<T>? query = new QueryActionRepository<T>(dbSet.AsQueryable(), queryParams).GetWhereClause();

        query = new QueryPageParamsRepository<T>().GetWhereClause(queryParams, query);

        int page = queryParams?.Page ?? 1;
        int pageSize = queryParams?.PageSize ?? 10;

        query = query.Skip((page - 1) * pageSize).Take(pageSize);

        var data = await query.ToListAsync();

        return new QueryResult<T>
        {
            Data = data,
            Total = data.Count,
            Page = page,
            PageSize = pageSize
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
