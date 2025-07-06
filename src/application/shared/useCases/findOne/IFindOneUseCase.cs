
namespace med_consult_api.src.application;

public interface IFindOneUseCase<R>
{
    public Task<R> ExecuteAsync(Guid id);
}