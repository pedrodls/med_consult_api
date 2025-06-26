
namespace med_consult_api.src.application;

public interface IUseCase<T, D>
{
        public Task<D> ExecuteAsync(T entity);
}