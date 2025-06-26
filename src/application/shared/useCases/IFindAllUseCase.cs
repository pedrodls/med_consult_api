
namespace med_consult_api.src.application;

public interface IFindAllUseCase<T, D>
{
        public Task<PageResult<T>> ExecuteAsync(
            string? parameters,
            PageParams? paginateParams = null);
}