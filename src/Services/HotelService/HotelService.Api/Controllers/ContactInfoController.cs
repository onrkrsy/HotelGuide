using HotelService.Application.Services.Abstract;
using HotelService.Domain.Entities;
using HotelService.Application.Services.Abstract;
using HotelService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult ListContactInfos()
        {
            var ContactInfos = _contactInfoService.GetAll();
            return Ok(ContactInfos);
        }


        [HttpGet("{id}")]
        public IActionResult GetContactInfo(Guid id)
        {
            var ContactInfo = _contactInfoService.Get(id);
            if (ContactInfo == null)
            {
                return NotFound();
            }
            return Ok(ContactInfo);
        }


        [HttpPost]
        public IActionResult CreateContactInfo([FromBody] ContactInfo ContactInfo)
        {
            _contactInfoService.Add(ContactInfo);
            return CreatedAtAction(nameof(GetContactInfo), new { id = ContactInfo.Id }, ContactInfo);
        }


        [HttpPut]
        public IActionResult UpdateContactInfo([FromBody] ContactInfo ContactInfo)
        {
            _contactInfoService.Update(ContactInfo);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveContactInfo(Guid id)
        {
            var ContactInfo = _contactInfoService.Get(id);
            if (ContactInfo == null)
            {
                return NotFound();
            }

            _contactInfoService.Delete(id);
            return NoContent();
        }
    }
}
