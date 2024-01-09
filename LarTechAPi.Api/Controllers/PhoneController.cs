using LarTechAPi.Application.DTOs;
using LarTechAPi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LarTechAPi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;
        
        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhones()
        {
            var result = await _phoneService.GetPhones();

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPhoneById(int? id)
        {
            var result = await _phoneService.GetPhoneById(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhone(PhoneDTO phoneDTO)
        {
            var result = await _phoneService.CreatePhone(phoneDTO);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePhone(PhoneDTO phoneDTO)
        {
            var result = await _phoneService.UpdatePhone(phoneDTO);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePhone(int? id)
        {
            var result = await _phoneService.DeletePhone(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }
    }
}
