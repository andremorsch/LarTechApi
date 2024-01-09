using LarTechAPi.Application.DTOs;
using LarTechAPi.Application.Services;

namespace LarTechAPi.Application.Interfaces
{
    public interface IPhoneService
    {
        Task<ResultService<IEnumerable<PhoneDTO>>> GetPhones();
        Task<ResultService<PhoneDTO>> GetPhoneById(int? id);
        Task<ResultService<PhoneDTO>> CreatePhone(PhoneDTO phoneDTO);
        Task<ResultService<PhoneDTO>> UpdatePhone(PhoneDTO phoneDTO);
        Task<ResultService<PhoneDTO>> DeletePhone(int? id);
    }
}
