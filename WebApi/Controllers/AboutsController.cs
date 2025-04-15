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
            var dataResult = new DataResult<List<GetAboutDto>>(mappedResult, result.Success, result.Message);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _aboutService.GetByIdAsync(id);
            var mappedResult = _mapper.Map<GetByIdAboutDto>(result.Data);
            var dataResult = new DataResult<GetByIdAboutDto>(mappedResult, result.Success);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var data = _mapper.Map<About>(createAboutDto);
            var result = await _aboutService.AddAsync(data);
            return result.Success ? Ok(result) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
          var data =_mapper.Map<About>(updateAboutDto);
            var result=await _aboutService.UpdateAsync(data);
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var result = await _aboutService.GetByIdAsync(id);
            await _aboutService.DeleteAsync(result.Data);
            return Ok(Messages.ProductDeleted);

        }

    }

}
