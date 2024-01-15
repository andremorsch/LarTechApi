using AutoMapper;
using LarTechAPi.Application.DTOs;
using LarTechAPi.Application.Services;
using LarTechAPi.Domain.Interfaces;
using LarTechAPi.Domain.Entities;
using Moq;

namespace LarTechApi.XUnitTests.Services
{
    public class PersonServiceTest
    {
        private Mock<IPersonRepository> _personRepository;
        private PersonService _personService;

        [Fact(DisplayName = "Deve criar uma pessoa")]
        public async Task CreateAsync_ShouldSaveAPerson()
        {
            var dto = new PersonDTO() 
            {
                Id = 1,
                Name  = "Testando ABC",
                Cpf = "12345678910",
                Birthday = new DateTime(1996, 01, 01),
                IsActive = true
            };
            var person = new Person(1, "Testando ABC", "12345678910", new DateTime(1996, 01, 01), true);

            _personRepository = new Mock<IPersonRepository>();
            _personRepository.Setup(x => x.CreatePersonAsync(It.IsAny<Person>()))
                .ReturnsAsync(person);

            _personService = new PersonService(_personRepository.Object, new BaseTest().GetMapper());
            var result = await _personService.CreatePerson(dto);

            Assert.NotNull(result);
            Assert.True(result.Success);

            _personRepository.Verify(x => x.CreatePersonAsync(It.IsAny<Person>()), Times.Once());
        }

        [Fact(DisplayName = "Não deve criar uma pessoa")]
        public async Task CreateAsync_ShouldNotSaveAPerson()
        {
            var dto = new PersonDTO() 
            {
                Id = 1,
                Name  = "Testando ABC",
                Cpf = "errado",
                Birthday = new DateTime(1996, 01, 01),
                IsActive = true
            };
            _personRepository = new Mock<IPersonRepository>();
            _personRepository.Setup(x => x.CreatePersonAsync(It.IsAny<Person>()))
                .ReturnsAsync(It.IsAny<Person>());

            _personService = new PersonService(_personRepository.Object, new BaseTest().GetMapper());
            var result = await _personService.CreatePerson(dto);

            Assert.False(result.Success);
            _personRepository.Verify(x => x.CreatePersonAsync(It.IsAny<Person>()), Times.Never());
        }

        [Fact(DisplayName = "Erro no DB ao tentar criar uma pessoa")]
        public async Task CreateAsync_ShouldNotSaveAPersonDB()
        {
            var dto = new PersonDTO()
            {
                Id = 1,
                Name = "Testando ABC",
                Cpf = "12345678910",
                Birthday = new DateTime(1996, 01, 01),
                IsActive = true
            };

            _personRepository = new Mock<IPersonRepository>();
            _personRepository.Setup(x => x.CreatePersonAsync(It.IsAny<Person>()))
                .ReturnsAsync(It.IsAny<Person>());

            _personService = new PersonService(_personRepository.Object, new BaseTest().GetMapper());
            var result = await _personService.CreatePerson(dto);

            Assert.False(result.Success);
            _personRepository.Verify(x => x.CreatePersonAsync(It.IsAny<Person>()), Times.Once());
        }
    }
}
