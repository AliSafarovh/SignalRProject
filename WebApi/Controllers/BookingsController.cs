using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.BookingDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingsService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingsService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _bookingsService.GetAllAsync();
            return result.Success ? Ok(result) : NotFound();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _bookingsService.GetByIdAsync(id);
            return value.Success ? Ok(value.Data) : NotFound(value.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromForm] CreateBookingDto createBookingDto)
        {
            var result = await _bookingsService.AddAsync(_mapper.Map<Booking>(createBookingDto));
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Updatebooking([FromForm] UpdateBookingDto updateBookingDto)
        {
            var values = await _bookingsService.UpdateAsync(_mapper.Map<Booking>(updateBookingDto));
            return values.Success ? Ok(Messages.ProductUpdated) : BadRequest(values.Message);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var value = await _bookingsService.GetByIdAsync(id);
            await _bookingsService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}
