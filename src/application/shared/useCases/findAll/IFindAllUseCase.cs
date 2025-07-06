
namespace med_consult_api.src.application;

public interface IFindAllUseCase<T, D>
{
        public Task<PageResult<D>> ExecuteAsync(
            string? parameters,
            PageParams? paginateParams = null
        );
}