using HotelService.Application.Models;
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
        [HttpGet("ListHotels")]
        public async Task<IActionResult> ListHotels()
        {
            var hotels = await _hotelService.GetAll();
            return Ok(hotels);
        }

   
        [HttpGet("Get/{id}")]
        public IActionResult GetHotel(Guid id)
        {
            var hotel = _hotelService.Get(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

      
        [HttpPost("CreateHotel")]

        public IActionResult CreateHotel([FromBody] CreateHotelDto hotel)
        {
            _hotelService.Add(hotel);
            return CreatedAtAction(nameof(GetHotel), new { Name = hotel.Name }, hotel);
        }

     
        [HttpPut("UpdateHotel")]
        public IActionResult UpdateHotel([FromBody] UpdateHotelDto hotel)
        {   
            _hotelService.Update(hotel);
            return NoContent();
        }

    
        [HttpDelete("RemoveHotel/{id}")]
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
