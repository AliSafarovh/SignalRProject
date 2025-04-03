using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.AboutDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutsController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _aboutService.GetAllAsync();
            var mappedResult = _mapper.Map<List<GetAboutDto>>(result.Data);
            return result.Success ? Ok(mappedResult) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _aboutService.GetByIdAsync(id);
            return value.Success ? Ok(_mapper.Map<GetByIdAboutDto>(value.Data)) : NotFound(value.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromForm] CreateAboutDto createAboutDto)
        {
            var result = await _aboutService.AddAsync(_mapper.Map<About>(createAboutDto));
            return result.Success ? Ok(result) : BadRequest(result.Message);
            //await _aboutService.AddAsync(new About()
            //{
            //    Title= createAboutDto.Title,
            //    Description= createAboutDto.Description,
            //    ImageUrl= createAboutDto.ImageUrl,
            //});
            //return Ok("Yuklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout([FromForm] UpdateAboutDto updateAboutDto)
        {
            var result = await _aboutService.UpdateAsync(_mapper.Map<About>(updateAboutDto));
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var value = await _aboutService.GetByIdAsync(id);
            await _aboutService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);

        }

    }

}
