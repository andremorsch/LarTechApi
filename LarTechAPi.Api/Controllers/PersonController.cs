using LarTechAPi.Application.DTOs;
using LarTechAPi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LarTechAPi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var result = await _personService.GetPeople();

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPersonById(int? id)
        {
            var result = await _personService.GetPersonById(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpGet]
        [Route("cpf/{cpf}")]
        public async Task<IActionResult> GetPersonByCpf(string cpf)
        {
            var result = await _personService.GetPersonByCpf(cpf);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonDTO personDTO)
        {
            var result = await _personService.CreatePerson(personDTO);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson(PersonDTO personDTO)
        {
            var result = await _personService.UpdatePerson(personDTO);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePerson(int? id)
        {
            var result = await _personService.DeletePerson(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }
    }
}
