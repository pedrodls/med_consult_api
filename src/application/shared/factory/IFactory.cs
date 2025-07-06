using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public interface IFactory<T, C, U>
    where T : DomainModel
    where U: UpdateDTO
{
    public T Create(C createDTO);

    public T Update(T entity, U updateDTO);
}