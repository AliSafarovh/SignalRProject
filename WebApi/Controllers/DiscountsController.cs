using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs.ContactDtos;
using Entities.DTOs.DiscountDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountsController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _discountService.GetAllAsync();
            var mappedResult = _mapper.Map<List<GetDiscountDto>>(result.Data);
            return result.Success ? Ok(mappedResult) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _discountService.GetByIdAsync(id);
            return result.Success ? Ok(_mapper.Map<GetByIdDiscountDto>(result.Data)) : NotFound(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromForm] CreateDiscountDto createDiscountDto)
        {
            var result = await _discountService.AddAsync(_mapper.Map<Discount>(createDiscountDto));
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscount([FromForm] UpdateDiscountDto updateDiscountDto)
        {
            var result = await _discountService.UpdateAsync(_mapper.Map<Discount>(updateDiscountDto));
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var value = await _discountService.GetByIdAsync(id);
            await _discountService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }

    }
}
