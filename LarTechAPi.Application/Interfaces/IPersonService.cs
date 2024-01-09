using LarTechAPi.Application.DTOs;
using LarTechAPi.Application.Services;

namespace LarTechAPi.Application.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<IEnumerable<PersonDTO>>> GetPeople();
        Task<ResultService<PersonDTO>> GetPersonById(int? id);
        Task<ResultService<PersonDTO>> GetPersonByCpf(string cpf);
        Task<ResultService<PersonDTO>> CreatePerson(PersonDTO personDTO);
        Task<ResultService<PersonDTO>> UpdatePerson(PersonDTO personDTO);
        Task<ResultService<PersonDTO>> DeletePerson(int? id);
    }
}
