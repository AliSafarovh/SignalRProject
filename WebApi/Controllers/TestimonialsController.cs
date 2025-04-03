using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CategoryDtos;
using Entities.DTOs.TestimonialDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _testimonialService.GetAllAsync();
            var mappedResult =_mapper.Map<List<GetTestimonialDto>>(result.Data);
            return result.Success ? Ok(mappedResult) : NotFound(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _testimonialService.GetByIdAsync(id);
            return result.Success ? Ok(_mapper.Map<GetByIdTestimonialDto>(result.Data)) : NotFound(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial([FromForm] CreateTestimonialDto createTestimonialDto)
        {
            var result = await _testimonialService.AddAsync(_mapper.Map<Testimonial>(createTestimonialDto));
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial([FromForm] UpdateTestimonialDto updateTestimonialDto)
        {
            var result = await _testimonialService.UpdateAsync(_mapper.Map<Testimonial>(updateTestimonialDto));
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var value = await _testimonialService.GetByIdAsync(id);
            await _testimonialService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }

}
