using LarTechAPi.Domain.Entities;

namespace LarTechAPi.Domain.Interfaces
{
    public interface IPhoneRepository
    {
        Task<IEnumerable<Phosne>> GetPhonesAsync();
        Task<Phone> GetPhoneByIdAsync(int id);
        Task<Phone> CreatePhoneAsync(Phone phone);
        Task<Phone> UpdatePhoneAsync(Phone phone);
        Task<Phone> DeletePhoneAsync(Phone phone);
    }
}
