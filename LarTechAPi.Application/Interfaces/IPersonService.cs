using LarTechAPi.Application.DTOs;

namespace LarTechAPi.Application.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTO>> GetPeople();
        Task<PersonDTO> GetPersonById(int? id);
        Task<PersonDTO> CreatePerson(PersonDTO personDTO);
        Task UpdatePerson(PersonDTO personDTO);
        Task DeletePerson(int? id);
    }
}
