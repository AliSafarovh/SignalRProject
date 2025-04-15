using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.FeatureDetailDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureDetailsController : ControllerBase
    {
        private readonly IFeatureDetailService _featureDetailService;
        private readonly IMapper _mapper;
        public FeatureDetailsController(IFeatureDetailService featureDetailService, IMapper mapper)
        {
            _featureDetailService = featureDetailService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _featureDetailService.GetAllAsync();
            var mappedResult = _mapper.Map<List<GetFeatureDetailDto>>(result.Data);
            var dataResult = new DataResult<List<GetFeatureDetailDto>>(mappedResult, result.Success, result.Message);
            return result.Success ? Ok(dataResult) : BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _featureDetailService.GetByIdAsync(id);
            var mappedResult = _mapper.Map<GetByIdFeatureDetailDto>(result.Data);
            var dataResult = new DataResult<GetByIdFeatureDetailDto>(mappedResult, result.Success);
            return result.Success ? Ok(dataResult) : BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureDetail(CreateFeatureDetailDto createFeatureDetailDto)
        {
            var data = _mapper.Map<FeatureDetail>(createFeatureDetailDto);
            var result = await _featureDetailService.AddAsync(data);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureDetail(UpdateFeatureDetailDto updateFeatureDetailDto)
        {
            var data = _mapper.Map<FeatureDetail>(updateFeatureDetailDto);
            var result = await _featureDetailService.UpdateAsync(data);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureDetail(int id)
        {
            var data = await _featureDetailService.GetByIdAsync(id);
            await _featureDetailService.DeleteAsync(data.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}

