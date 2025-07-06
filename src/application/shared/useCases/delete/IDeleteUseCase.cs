
namespace med_consult_api.src.application;

//T - Entity type
//D - Delivery type

public interface IDeleteUseCase
{
        public Task<Response> ExecuteAsync(Guid id);
}