
namespace med_consult_api.src.application;

public interface IFindAllUseCase<T, D>
{
        public Task<QueryResult<D>> ExecuteAsync(
            Query? queryParams = null
        );
}