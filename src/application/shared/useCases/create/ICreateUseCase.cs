
namespace med_consult_api.src.application;

//T - Entity type
//D - Delivery type

public interface ICreateUseCase<T, R>
{
        public Task<R> ExecuteAsync(T entity);
}