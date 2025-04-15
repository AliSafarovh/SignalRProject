using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
            var dataResult = new DataResult<List<GetDiscountDto>>(mappedResult, result.Success, result.Message);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _discountService.GetByIdAsync(id);
            var mappedResult = _mapper.Map<GetByIdDiscountDto>(result.Data);
            var dataResult = new DataResult<GetByIdDiscountDto>(mappedResult, result.Success);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var data = _mapper.Map<Discount>(createDiscountDto);
            var result=await _discountService.AddAsync(data);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var data=_mapper.Map<Discount>(updateDiscountDto);
            var result= await _discountService.UpdateAsync(data);
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var value = await _discountService.GetByIdAsync(id);
            await _discountService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }

    }
}
