using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
            var dataResult=new DataResult<List<GetTestimonialDto>>(mappedResult,result.Success,result.Message);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _testimonialService.GetByIdAsync(id);
            var mappedResult=_mapper.Map<GetByIdTestimonialDto>(result.Data);
            var dataResult=new DataResult<GetByIdTestimonialDto>(mappedResult,result.Success);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var data=_mapper.Map<Testimonial>(createTestimonialDto);
            var result = await _testimonialService.AddAsync(data);
            return result.Success ? Ok(result.Message) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var data = _mapper.Map<Testimonial>(updateTestimonialDto);
            var result=await _testimonialService.UpdateAsync(data);
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var value = await _testimonialService.GetByIdAsync(id);
            await _testimonialService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }

}
