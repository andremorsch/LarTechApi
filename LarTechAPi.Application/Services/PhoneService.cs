using AutoMapper;
using LarTechAPi.Application.DTOs;
using LarTechAPi.Application.Interfaces;
using LarTechAPi.Domain.Entities;
using LarTechAPi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarTechAPi.Application.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly IMapper _mapper;

        public PhoneService(IPhoneRepository phoneRepository, IMapper mapper)
        {
            _phoneRepository = phoneRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PhoneDTO>> CreatePhone(PhoneDTO phoneDTO)
        {
            try
            {
                var phone = _mapper.Map<Phone>(phoneDTO);
                var newPhone = await _phoneRepository.CreatePhoneAsync(phone);

                if (newPhone == null)
                    return new ResultService<PhoneDTO>(400, false, "Bad Request", null);

                var result = _mapper.Map<PhoneDTO>(newPhone);

                return new ResultService<PhoneDTO>(200, true, "Success", result);
            }
            catch (Exception ex)
            {
                return new ResultService<PhoneDTO>(500, false, ex.Message, null);
            }
        }

        public async Task<ResultService<PhoneDTO>> DeletePhone(int? id)
        {
            try
            {
                var phone = await _phoneRepository.GetPhoneByIdAsync(id.Value);

                if (phone == null)
                    return new ResultService<PhoneDTO>(400, false, "Bad Request", null);

                await _phoneRepository.DeletePhoneAsync(phone);

                return new ResultService<PhoneDTO>(200, true, "Success", null);
            }
            catch (Exception ex)
            {
                return new ResultService<PhoneDTO>(500, false, ex.Message, null);
            }
        }

        public async Task<ResultService<PhoneDTO>> GetPhoneById(int? id)
        {
            try
            {
                var phone = await _phoneRepository.GetPhoneByIdAsync(id.Value);

                if (phone == null)
                    return new ResultService<PhoneDTO>(400, false, "Bad Request", null);

                var result = _mapper.Map<PhoneDTO>(phone);

                return new ResultService<PhoneDTO>(200, true, "Success", result);
            }
            catch (Exception ex)
            {
                return new ResultService<PhoneDTO>(500, false, ex.Message, null);
            }
        }

        public async Task<ResultService<IEnumerable<PhoneDTO>>> GetPhones()
        {
            try
            {
                var phones = await _phoneRepository.GetPhonesAsync();
                var phonesDTO = _mapper.Map<IEnumerable<PhoneDTO>>(phones);

                return new ResultService<IEnumerable<PhoneDTO>>(200, true, "Success", phonesDTO);
            }
            catch (Exception ex)
            {
                return new ResultService<IEnumerable<PhoneDTO>>(500, false, ex.Message, null);
            }
        }

        public async Task<ResultService<PhoneDTO>> UpdatePhone(PhoneDTO phoneDTO)
        {
            try
            {
                var phone = _mapper.Map<Phone>(phoneDTO);
                var newPhone = await _phoneRepository.UpdatePhoneAsync(phone);

                return new ResultService<PhoneDTO>(200, true, "Success", null);
            }
            catch (Exception ex)
            {
                return new ResultService<PhoneDTO>(500, false, ex.Message, null);
            }
        }
    }
}
