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
            var mappedResult = _mapper.Map<List<GetCategoryDto>>(result.Data);
            var dataResult = new DataResult<List<GetCategoryDto>>(mappedResult, result.Success, result.Message);
            return result.Success ? Ok(dataResult) : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            var mapping = _mapper.Map<GetByIdCategoryDto>(result.Data);  
            var dataResult = new DataResult<GetByIdCategoryDto>(mapping,result.Success);
            return result.Success ? Ok(dataResult) : BadRequest(result.Message);

        }
        [HttpGet("CategoryWithProducts")]
        public async Task<IActionResult> GetByCategoryWithProducts(int id)
        {
            var result = await _categoryService.TGetCategoryWithProducts(id);
            var mappedResult = _mapper.Map<List<GetCategoryWithProductsDto>>(result.Data);
            return result.Success ? Ok(mappedResult) : NotFound(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var data = _mapper.Map<Category>(createCategoryDto);
            var result = await _categoryService.AddAsync(data);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory( UpdateCategoryDto updateCategoryDto)
        {
            var data = _mapper.Map<Category>(updateCategoryDto);
            var result = await _categoryService.UpdateAsync(data);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var value = await _categoryService.GetByIdAsync(id);
            await _categoryService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}
