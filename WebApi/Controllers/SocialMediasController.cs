using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
            var result = await _socialMediaService.GetAllAsync();
            var mappedResult = _mapper.Map<List<GetSocialMediaDto>>(result.Data);
            var dataResult = new DataResult<List<GetSocialMediaDto>>(mappedResult, result.Success, result.Message);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _socialMediaService.GetByIdAsync(id);
            var mappedResult = _mapper.Map<GetByIdSocialMediaDto>(result.Data);
            var dataResult = new DataResult<GetByIdSocialMediaDto>(mappedResult, result.Success);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var data = _mapper.Map<SocialMedia>(createSocialMediaDto);
            var result = await _socialMediaService.AddAsync(data);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var data = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            var result = await _socialMediaService.UpdateAsync(data);
            return result.Success ? Ok(result.Message) : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var value = await _socialMediaService.GetByIdAsync(id);
            await _socialMediaService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}
