using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.AboutDtos;
using Entities.DTOs.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _productService.GetAllAsync();
            var mappedResult = _mapper.Map<List<GetProductDto>>(result.Data);
            return result.Success ? Ok(mappedResult) : NotFound();

        }

        [HttpGet("ProductsByWithCategory")]
        public async Task<IActionResult> GetListByWithCategory()
        {
            var result = await _productService.TGetProductwithCategory();
            var mappedResult = _mapper.Map<List<ResultProductWithcategoryDto>>(result.Data);
            return result.Success ? Ok(mappedResult) : NotFound(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetListById(int id)
        {
            var value = await _productService.GetByIdAsync(id);
            return value.Success ? Ok(value) : NotFound(value.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]CreateProductDto creteProductDto)
        {
            var result = await _productService.AddAsync(_mapper.Map<Product>(creteProductDto));
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateProductDto updateProductDto)
        {
            var result = await _productService.UpdateAsync(_mapper.Map<Product>(updateProductDto));
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var value =await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}

