using med_consult_api.src.domain;

namespace med_consult_api.src.application;

public interface IFactory<T, D>
    where T : DomainModel
{
    public T Create(D createDTO);
}