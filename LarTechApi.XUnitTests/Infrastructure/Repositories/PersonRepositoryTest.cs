using LarTechApi.XUnitTests.Infrastructure.Context;
using LarTechAPi.Domain.Entities;
using LarTechAPi.Infrastructure.Context;
using LarTechAPi.Infrastructure.Repositories;

namespace LarTechApi.XUnitTests.Infrastructure.Repositories
{
    public class PersonRepositoryTest
    {
        private ApplicationDbContext _context;

        [Fact(DisplayName = "Deve salvar uma pessoa no DB")]
        public async Task Create_ShouldSaveAPerson()
        {
            var person = new Person("Testando ABC", "12345678910", new DateTime(1996, 01, 01), true);
            _context = DatabaseTestInMemory.GetDatabase();

            var personRepository = new PersonRepository(_context);
            await personRepository.CreatePersonAsync(person);

            var result = _context.People.FirstOrDefault();
            Assert.Equal(person, result);
            Assert.Equal(person.Cpf, result!.Cpf);

        }

        [Fact(DisplayName = "Deve retornar uma pessoa do DB pelo ID")]
        public async Task GetByID_ShouldGetAPersonById()
        {
            var person = new Person("Testando ABC", "12345678910", new DateTime(1996, 01, 01), true);
            _context = DatabaseTestInMemory.GetDatabase();
            _context.People.Add(person);
            _context.SaveChanges();

            var personRepository = new PersonRepository(_context);
            var result = await personRepository.GetPersonByIdAsync(1);

            Assert.Equal(person, result);
            Assert.Equal(person.Cpf, result.Cpf);
        }

        [Fact(DisplayName = "Deve Deletar uma pessoa do DB")]
        public async Task Delete_ShouldDeleteAPerson()
        {
            var person = new Person("Testando ABC", "12345678910", new DateTime(1996, 01, 01), true);
            _context = DatabaseTestInMemory.GetDatabase();
            _context.People.Add(person);
            _context.SaveChanges();

            var personRepository = new PersonRepository(_context);
            var resultGet = await personRepository.GetPersonByIdAsync(1);
            var resultDelete = await personRepository.DeletePersonAsync(resultGet);
            var result = await personRepository.GetPersonByIdAsync(1);


            Assert.Equal(resultGet, resultDelete);
            Assert.Equal(resultGet.Cpf, resultDelete.Cpf);
            Assert.Null(result);
        }

        [Fact(DisplayName = "Deve retornar uma pessoa do DB pelo CPF")]
        public async Task GetByCPF_ShouldGetPersonByCpf()
        {
            var person = new Person("Testando ABC", "12345678910", new DateTime(1996, 01, 01), true);
            _context = DatabaseTestInMemory.GetDatabase();
            _context.People.Add(person);
            _context.SaveChanges();

            var personRepository = new PersonRepository(_context);
            var result = await personRepository.GetPersonByCpfAsync("12345678910");

            Assert.Equal(person, result);
            Assert.Equal(person.Id, result.Id);
        }

        [Fact(DisplayName = "Deve retornar todos cadastros de pessoas do DB")]
        public async Task Update_ShouldGetPeople()
        {
            var person1 = new Person(1, "Testando ABC", "12345678910", new DateTime(1996, 01, 01), true);
            var person2 = new Person(2, "Testando DEF", "01987654321", new DateTime(1969, 01, 01), false);
            _context = DatabaseTestInMemory.GetDatabase();
            _context.People.Add(person1);
            _context.People.Add(person2);
            _context.SaveChanges();

            var personRepository = new PersonRepository(_context);
            var result = await personRepository.GetPeopleAsync();

            Assert.Equal(result.FirstOrDefault(x => x.Id == 1), person1);
            Assert.Equal(result.FirstOrDefault(x => x.Id == 2), person2);
        }
    }
}
