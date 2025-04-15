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
            var dataResult = new DataResult<List<GetProductDto>>(mappedResult, result.Success, result.Message); 
            return result.Success ? Ok(dataResult) : NotFound();

        }

        [HttpGet("ProductsByWithCategory")]
        public async Task<IActionResult> GetListByWithCategory()
        {
            var result = await _productService.TGetProductwithCategory();
            var mappedResult = _mapper.Map<List<ResultProductWithcategoryDto>>(result.Data);
            var dataResult = new DataResult<List<ResultProductWithcategoryDto>>(mappedResult, result.Success, result.Message);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            var mappedResult = _mapper.Map<GetByIdProductDto>(result.Data);
            var dataResult = new DataResult<GetByIdProductDto>(mappedResult, result.Success);
            return result.Success ? Ok(dataResult) : NotFound(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var data = _mapper.Map<Product>(createProductDto);
            var result = await _productService.AddAsync(data);
            return result.Success ? Ok(result.Message) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var data=_mapper.Map<Product>(updateProductDto);
            var result = await _productService.UpdateAsync(data);
            return result.Success ? Ok(result.Message) : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var value =await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }
    }
}

