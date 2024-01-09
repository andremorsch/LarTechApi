using AutoMapper;
using LarTechAPi.Application.DTOs;
using LarTechAPi.Application.Interfaces;
using LarTechAPi.Domain.Entities;
using LarTechAPi.Domain.Interfaces;

namespace LarTechAPi.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PersonDTO>> CreatePerson(PersonDTO personDTO)
        {
            try
            {
                var person = _mapper.Map<Person>(personDTO);
                var newPerson = await _personRepository.CreatePersonAsync(person);

                if (newPerson == null)
                {
                    return new ResultService<PersonDTO>(400, false, "Bad Request", null);
                }

                var result = _mapper.Map<PersonDTO>(newPerson);

                return new ResultService<PersonDTO>(200, true, "Success", result);
            }
            catch (Exception ex)
            {
                return new ResultService<PersonDTO>(500, false, ex.Message, null);
            }
        }

        public async Task<ResultService<PersonDTO>> DeletePerson(int? id)
        {
            try
            {
                var person = await _personRepository.GetPersonByIdAsync(id.Value);
                await _personRepository.DeletePersonAsync(person);

            }
        }

        public async Task<ResultService<IEnumerable<PersonDTO>>> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Task<ResultService<PersonDTO>> GetPersonByCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultService<PersonDTO>> GetPersonById(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultService<PersonDTO>> UpdatePerson(PersonDTO personDTO)
        {
            throw new NotImplementedException();
        }
    }
}
