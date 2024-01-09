using LarTechAPi.Application.DTOs;

namespace LarTechAPi.Application.Interfaces
{
    public interface IPhoneService
    {
        Task<IEnumerable<PhoneDTO>> GetPhones();
        Task<PhoneDTO> GetPhoneById(int? id);
        Task<PhoneDTO> CreatePhone(PhoneDTO phoneDTO);
        Task UpdatePhone(PhoneDTO phoneDTO);
        Task DeletePhone(int? id);
    }
}
