using HotelService.Application.Services.Abstract;
using HotelService.Domain.Entities;
using HotelService.Application.Services.Abstract;
using HotelService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelService.Application.Models;

namespace ContactInfoService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoBusiness _contactInfoService;

        public ContactInfoController(IContactInfoBusiness contactInfoRepository)
        {
            _contactInfoService = contactInfoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ListContactInfos()
        {

            var ContactInfos = await _contactInfoService.GetAll();
            return Ok(ContactInfos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactInfo(Guid id)
        {
            var ContactInfo = await _contactInfoService.Get(id);
            if (ContactInfo == null)
            {
                return NotFound();
            }
            return Ok(ContactInfo);
        }


        [HttpPost]
        public async Task<IActionResult> CreateContactInfo([FromBody] CreateContactInfoDto contactInfo)
        {
             await _contactInfoService.Add(contactInfo);
            return CreatedAtAction(nameof(GetContactInfo), new { id = contactInfo.HotelId }, contactInfo);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateContactInfo([FromBody] UpdateContactInfoDto contactInfo)
        {
            await _contactInfoService.Update(contactInfo);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContactInfo(Guid id)
        {
            var ContactInfo = await _contactInfoService.Get(id);
            if (ContactInfo == null)
            {
                return NotFound();
            }

            _contactInfoService.Delete(id);
            return NoContent();
        }
    }
}
