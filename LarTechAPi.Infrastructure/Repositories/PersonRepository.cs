using LarTechAPi.Domain.Entities;
using LarTechAPi.Domain.Interfaces;
using LarTechAPi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LarTechAPi.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> DeletePersonAsync(Person person)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> GetPersonByCpfAsync(string cpf)
        {
            return await _context.People.FirstOrDefaultAsync(p => p.Cpf == cpf);
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.People.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Person> UpdatePersonAsync(Person person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();
            return person;
        }
    }
}
