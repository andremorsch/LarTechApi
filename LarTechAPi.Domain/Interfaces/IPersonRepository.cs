using LarTechAPi.Domain.Entities;

namespace LarTechAPi.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeopleAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task<Person> GetPersonByCpfAsync(string cpf);
        Task<Person> CreatePersonAsync(Person person);
        Task<Person> UpdatePersonAsync(Person person);
        Task<Person> DeletePersonAsync(Person person);
    }
}
