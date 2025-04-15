using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CategoryDtos;
using Entities.DTOs.FeatureDtos;
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
            _featureService = featureService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _featureService.GetAllAsync();
            var mappedResult = _mapper.Map<List<GetFeatureDto>>(result.Data);
            var dataResult = new DataResult<List<GetFeatureDto>>(mappedResult, result.Success, result.Message);
            return result.Success ? Ok(dataResult) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _featureService.GetByIdAsync(id);
            var mappingResult = _mapper.Map<GetByIdFeatureDto>(result.Data);
            var dataResult = new DataResult<GetByIdFeatureDto>(mappingResult, result.Success);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var data = _mapper.Map<Feature>(createFeatureDto);
            var result = await _featureService.AddAsync(data);
            return result.Success ? Ok(result.Message) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var data = _mapper.Map<Feature>(updateFeatureDto);
            var result = await _featureService.UpdateAsync(data);
            return result.Success ? Ok(result.Message) : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var result = await _featureService.GetByIdAsync(id);
            await _featureService.DeleteAsync(result.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}
