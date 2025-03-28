using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        public FeaturesController(IFeatureService featureService, IMapper mapper)
        {
            _featureService=featureService;
            _mapper=mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _featureService.GetAllAsync();
            return values.Success ? Ok(values) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _featureService.GetByIdAsync(id);
            return value.Success ? Ok(value.Data) : NotFound(value.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature([FromForm] Feature feature)
        {
            var result = await _featureService.AddAsync(feature);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature([FromForm] Feature feature)
        {
            var result = await _featureService.UpdateAsync(feature);
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var value = await _featureService.GetByIdAsync(id);
            await _featureService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}
