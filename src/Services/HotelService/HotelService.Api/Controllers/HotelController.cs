using HotelService.Application.Services.Abstract;
using HotelService.Domain.Entities;
using HotelService.Infrastructure.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelsBusiness _hotelService;

        public HotelController(IHotelsBusiness hotelRepository)
        {
            _hotelService = hotelRepository;
        }

       
        [HttpGet]
        public IActionResult ListHotels()
        {
            var hotels = _hotelService.GetAll();
            return Ok(hotels);
        }

   
        [HttpGet("{id}")]
        public IActionResult GetHotel(Guid id)
        {
            var hotel = _hotelService.Get(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

      
        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            _hotelService.Add(hotel);
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

     
        [HttpPut]
        public IActionResult UpdateHotel([FromBody] Hotel hotel)
        {   
            _hotelService.Update(hotel);
            return NoContent();
        }

    
        [HttpDelete("{id}")]
        public IActionResult RemoveHotel(Guid id)
        {
            var hotel = _hotelService.Get(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _hotelService.Delete(id);
            return NoContent();
        }
    }
}
