using LarTechAPi.Domain.Entities;
using LarTechAPi.Domain.Interfaces;
using LarTechAPi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LarTechAPi.Infrastructure.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private ApplicationDbContext _context;

        public async Task<Phone> CreatePhoneAsync(Phone phone)
        {
            _context.Phones.Add(phone);
            await _context.SaveChangesAsync();
            return phone;
        }

        public async Task<Phone> DeletePhoneAsync(Phone phone)
        {
            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
            return phone;
        }

        public async Task<Phone> GetPhoneByIdAsync(int id)
        {
            return await _context.Phones.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Phone>> GetPhonesAsync()
        {
            return await _context.Phones.ToListAsync();
        }

        public async Task<Phone> UpdatePhoneAsync(Phone phone)
        {
            _context.Phones.Update(phone);
            await _context.SaveChangesAsync();
            return phone;
        }
    }
}
