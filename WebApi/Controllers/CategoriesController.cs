using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _categoryService.GetAllAsync();
            var mappedResult=_mapper.Map<List<GetCategoryDto>>(result.Data);
            var dataResult = new DataResult<List<GetCategoryDto>>(mappedResult, result.Success, result.Message);
            return result.Success ? Ok(dataResult) : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _categoryService.GetByIdAsync(id);

            return value.Success ? Ok(_mapper.Map<GetByIdCategoryDto>(value.Data)) : NotFound(value.Message);
        }
        [HttpGet("CategoryWithProducts")]
        public async Task<IActionResult> GetByCategoryWithProducts(int id)
        {
            var result = await _categoryService.TGetCategoryWithProducts(id);
            var mappedResult=_mapper.Map<List<GetCategoryWithProductsDto>>(result.Data);
            return result.Success ? Ok(mappedResult) : NotFound(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryDto createCategoryDto)
        {
            var result = await _categoryService.AddAsync(_mapper.Map<Category>(createCategoryDto));
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryDto updateCategoryDto)
        {
            var result = await _categoryService.UpdateAsync(_mapper.Map<Category>(updateCategoryDto));
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var value = await _categoryService.GetByIdAsync(id);
            await _categoryService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}
