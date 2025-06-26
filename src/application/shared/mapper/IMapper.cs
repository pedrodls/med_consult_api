using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public interface IMapper<T, R>
    where T : DomainModel
    where R : Dto
{
    T MapToEntity(R dto);
    R MapToDTO(T entity);

}