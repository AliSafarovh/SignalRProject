using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.BookingDtos;
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
            var mappedResult = _mapper.Map<List<GetBookingDto>>(result.Data);
            var dataResult = new DataResult<List<GetBookingDto>>(mappedResult, result.Success, result.Message);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bookingsService.GetByIdAsync(id);
            var mappedResult = _mapper.Map<GetByIdBookingDto>(result.Data);
            var dataResult = new DataResult<GetByIdBookingDto>(mappedResult, result.Success);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            var data = _mapper.Map<Booking>(createBookingDto);
            var result = await _bookingsService.AddAsync(data);
            return result.Success ? Ok(data) : BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> Updatebooking(UpdateBookingDto updateBookingDto)
        {
            var data = _mapper.Map<Booking>(updateBookingDto);
            var result = await _bookingsService.UpdateAsync(data);
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var value = await _bookingsService.GetByIdAsync(id);
            await _bookingsService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}
