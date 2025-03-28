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
            var values = await _categoryService.GetAllAsync();
            return values.Success ? Ok(values) : NotFound(); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value=await _categoryService.GetByIdAsync(id);
            return value.Success ? Ok(value.Data) : NotFound(value.Message); 
        }
        [HttpPost]
        public async Task <IActionResult> CreateCategory([FromForm] CreateCategoryDto createCategoryDto)
        {
           var result= await _categoryService.AddAsync(_mapper.Map<Category>(createCategoryDto));
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
            var value =await _categoryService.GetByIdAsync(id);
            await _categoryService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}
