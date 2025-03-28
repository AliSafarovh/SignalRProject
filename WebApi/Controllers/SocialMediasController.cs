using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs.CategoryDtos;
using Entities.DTOs.SocialMediaDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public SocialMediasController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _socialMediaService.GetAllAsync();
            return values.Success ? Ok(values) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _socialMediaService.GetByIdAsync(id);
            return value.Success ? Ok(value.Data) : NotFound(value.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMediaService([FromForm] CreateSocialMediaDto createSocialMediaDto)
        {
            var result = await _socialMediaService.AddAsync(_mapper.Map<SocialMedia>(createSocialMediaDto));
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia([FromForm] UpdateSocialMediaDto updateSocialMediaDto)
        {
            var result = await _socialMediaService.UpdateAsync(_mapper.Map<SocialMedia>(updateSocialMediaDto));
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var value = await _socialMediaService.GetByIdAsync(id);
            await _socialMediaService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}
